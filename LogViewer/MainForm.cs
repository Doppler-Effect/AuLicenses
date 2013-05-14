using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Core;

namespace LogViewer
{
    public partial class MainForm : Form
    {
        StatesContainer statesContainer;
        bool ShowOnlyHolidays
        {
            get { return this.radioButtonHolidays.Checked; }
        }
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioButtonWorkDays_MouseClick(object sender, MouseEventArgs e)
        {
            this.statesContainer = new StatesContainer(PREFERENCES.Instance.LogDirectoryPath, this.ShowOnlyHolidays);
            DrawProductList();
        }

        private void radioButtonHolidays_MouseClick(object sender, MouseEventArgs e)
        {
            this.statesContainer = new StatesContainer(PREFERENCES.Instance.LogDirectoryPath, this.ShowOnlyHolidays);
            DrawProductList();
        }

        private void buttonOpenToday_Click(object sender, EventArgs e)
        {
            this.statesContainer = new StatesContainer(PREFERENCES.Instance.DailyLogDirectoryPath, this.ShowOnlyHolidays);
            DrawProductList();
        }

        private void buttonOpenDay_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Filter = String.Format("Daily log files (*{0})|*{0}", DailyState.FILEEXTENSION);
            dialog.Multiselect = true;
            dialog.InitialDirectory = PREFERENCES.Instance.LogDirectoryPath;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.statesContainer = new StatesContainer(dialog.FileNames, null);
                DrawProductList();
            }
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            this.statesContainer = new StatesContainer(PREFERENCES.Instance.LogDirectoryPath, null);
            DrawProductList(true);
        }
                     
        void DrawProductList(bool showUsers = false)
        {
            this.listBox1.Items.Clear();
            mainChart.Series.Clear();
            this.listBox1.SelectionMode = showUsers ? SelectionMode.One : SelectionMode.MultiSimple;

            if (this.statesContainer.States != null)
            {
                if (showUsers)
                {
                    DateRangeForm rangeForm = new DateRangeForm(this.statesContainer.Dates);
                    DialogResult result = rangeForm.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        YearAndMonth range = rangeForm.Result;
                        listBox1.Tag = range;
                        foreach (User U in this.statesContainer.Users)
                        {
                            this.listBox1.Items.Add(U.Name);
                        }
                    }
                }
                else
                {
                    listBox1.Tag = null;
                    foreach (Product P in this.statesContainer.AllProducts)
                    {
                        this.listBox1.Items.Add(P.Name);
                    }
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Tag == null)
                drawProductsChart(this.statesContainer.NormalizedStates);
            else
            {
                YearAndMonth range = (YearAndMonth)listBox1.Tag;
                drawUsersChart(this.statesContainer.States, range);
            }
        }

        void drawUsersChart(List<State> statesList, YearAndMonth Range)
        {      
            
            mainChart.Series.Clear();
            User CurrentUser = null;
            foreach (User U in this.statesContainer.Users)
            {
                if (U.Name == this.listBox1.SelectedItem.ToString())
                    CurrentUser = U;
            }

            if (CurrentUser != null)
            {
                ChartArea area = mainChart.ChartAreas[0];
                area.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
                area.AxisX.Interval = 1;
                area.AxisX.Title = "Дни";
                area.AxisY.Title = "Время, ч.";
                area.AxisY.Interval = 0.5;
                area.AxisY.Maximum = 12;

                Dictionary<Product, Series> data = new Dictionary<Product, Series>();

                foreach (DateTime date in this.statesContainer.Dates)
                {
                    if (date.Year == Range.Date.Year && date.Month == Range.Date.Month)
                    {
                        Dictionary<Product, double> dailyData = this.statesContainer.UserTimePerDay(CurrentUser, date);

                        foreach (Product P in dailyData.Keys)
                        {
                            if (!data.ContainsKey(P))
                            {
                                Series series = new Series(P.Name);
                                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                                series.LegendText = P.Name;

                                data.Add(P, series);
                            }
                            DataPoint point = new DataPoint(data[P]);
                            point.SetValueXY(date, dailyData[P]);
                            point.Tag = date;
                            data[P].Points.Add(point);
                        }
                    }
                }

                foreach (KeyValuePair<Product, Series> pair in data)
                {
                    mainChart.Series.Add(pair.Value);
                }
            }
        }
        
        void drawProductsChart(List<State> statesList)
        {            
            mainChart.Series.Clear();
            foreach(string name in this.listBox1.SelectedItems)
            {
                ChartArea area = mainChart.ChartAreas[0];

                area.AxisY.Title = "Количество лицензий";
                area.AxisY.Interval = 1;
                area.AxisY.Maximum = this.statesContainer.MaxUsersCount + 1;

                area.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                area.AxisX.Title = "Время";
                area.AxisX.Interval = 30;

                Series series = new Series(name);
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                series.BorderWidth = 5;
                series.LegendText = name;                
                
                foreach (State s in statesList)
                {
                    Product p = s.FindProductByName(name);
                    double y = p == null ? 0 : p.currUsersNum;

                    DataPoint point = new DataPoint(series);
                    point.SetValueXY(s.Datetime, y);
                    point.Tag = p;

                    series.Points.Add(point);
                }
                mainChart.Series.Add(series);               
            }
        }

        private bool SeriesNormalized(Series series)
        {
            foreach (DataPoint point in series.Points)
            {
                if (point.Tag != null)
                {
                    if (point.Tag.GetType() == typeof(Product))
                    {
                        Product p = (Product)point.Tag;
                        if (p.IsNormalized)
                            return true;
                    }
                }
            }
            return false;
        }
        private void mainChart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult pos = mainChart.HitTest(e.X, e.Y);
            if (pos.ChartElementType == ChartElementType.DataPoint)
            {
                //компоненты infoForm
                string Info = "No info found";
                string Header = null;
                bool CloseButton = false;
                //

                int pointIndex = pos.PointIndex;
                Series series = pos.Series;
                DataPoint point = series.Points[pointIndex];
                if (point.Tag.GetType() == typeof(Product))
                {
                    Product P = point.Tag as Product;
                    if (P != null)
                    {                        
                        if (SeriesNormalized(series))
                        {
                            //Header = "Усреднённые данные";
                            Info = String.Format("{0}: {1} из {2}", series.Name, P.currUsersNum, P.maxUsersNum);
                        }
                        else
                        {
                            Header = series.Name + "\n";
                            Info = String.Format("Использовано {0} из {1} лицензий:\n\n", P.currUsersNum, P.maxUsersNum);
                            CloseButton = true;
                            foreach (User user in P.Users)
                                Info += string.Format("{0}\n", user.Name);
                        }                        
                    }
                }
                if (point.Tag.GetType() == typeof(DateTime))
                {
                    DateTime date = (DateTime)point.Tag;
                    if (date != null)
                    {
                        Info = date.DayOfWeek.ToString().ToUpper();
                    }
                }

                Point location = e.Location;
                location.Offset(this.Location);
                location.Offset(this.mainChart.Location);
                InfoForm form = new InfoForm(Header, Info, location, CloseButton);
                form.Show(this);
            }
        }

        private void buttonProductNames_Click(object sender, EventArgs e)
        {
            if(this.statesContainer != null)
            {
                ProductNamesWindow win = new ProductNamesWindow(this.statesContainer.States);
                win.ShowDialog(this);
            }
        }        
        private void buttonHolidaysSelect_Click(object sender, EventArgs e)
        {
            HolidaysSelector window = new HolidaysSelector();
            window.ShowDialog(this);
        }        
    }    
}
