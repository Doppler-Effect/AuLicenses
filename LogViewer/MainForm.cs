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
                      
        void DrawProductList()
        {
            this.productsListBox.Items.Clear();
            mainChart.Series.Clear();

            if (this.statesContainer.States != null)
            {
                foreach (Product P in this.statesContainer.AllProducts)
                {
                    
                    this.productsListBox.Items.Add(P.Name, false);
                }
            }
        }
        private void productsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawProductsChart(this.statesContainer.NormalizedStates);
        }  
        
        void drawProductsChart(List<State> statesList)
        {            
            mainChart.Series.Clear();
            foreach (string name in this.productsListBox.CheckedItems)
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
                int pointIndex = pos.PointIndex;
                Series series = pos.Series;
                DataPoint point = series.Points[pointIndex];
                Product P = point.Tag as Product;
                if (P != null)
                {     
                    string Info = null;
                    string Header = null;
                    bool CloseButton = false;
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
                    Point location = e.Location;
                    location.Offset(this.Location);
                    location.Offset(this.mainChart.Location);
                    InfoForm form = new InfoForm(Header, Info, location, CloseButton);
                    form.Show(this);
                }
            }
        }

        private void buttonProductNames_Click(object sender, EventArgs e)
        {
            if(this.statesContainer != null)
            {
                ProductNamesWindow win = new ProductNamesWindow(this.statesContainer.States);
                win.Show(this);
            }
        }
        
        private void buttonHolidaysSelect_Click(object sender, EventArgs e)
        {
            HolidaysSelector window = new HolidaysSelector();
            window.Show(this);
        }
    }    
}
