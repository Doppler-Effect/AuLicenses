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
        ToolTip tooltip;

        public MainForm()
        {
            InitializeComponent();
        }

        private void radioButtonWorkDays_MouseClick(object sender, MouseEventArgs e)
        {
            makeStatesContainer(PREFERENCES.LogDirectoryPath);
        }

        private void radioButtonHolidays_MouseClick(object sender, MouseEventArgs e)
        {
            makeStatesContainer(PREFERENCES.LogDirectoryPath);
        }

        private void buttonOpenToday_Click(object sender, EventArgs e)
        {
            makeStatesContainer(PREFERENCES.DailyLogDirectoryPath);
        }

        private void buttonOpenDay_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Filter = String.Format("Daily log files (*{0})|*{0}", DailyState.FILEEXTENSION);
            dialog.Multiselect = true;
            dialog.InitialDirectory = PREFERENCES.LogDirectoryPath;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.makeStatesContainer(dialog.FileNames);
        } 

        private void productsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawChart(this.statesContainer.NormalizedStates);
        }

        void makeStatesContainer(string DirectoryPath)
        {            
            this.statesContainer = new StatesContainer(DirectoryPath, this.ShowOnlyHolidays);
            DrawProductList();
        }

        void makeStatesContainer(string[] files)
        {
            this.statesContainer = new StatesContainer(files, null);
            DrawProductList();
        }

        void DrawProductList()
        {
            this.productsListBox.Items.Clear();
            mainChart.Series.Clear();
            this.tooltip = null;

            if (this.statesContainer.States != null)
            {
                foreach (Product P in this.statesContainer.AllProducts)
                {
                    
                    this.productsListBox.Items.Add(P.Name, false);
                }
            }
        }
        
        void drawChart(List<State> statesList)
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
                    if (SeriesNormalized(series))
                    {
                        string Info = String.Format("{0}, усреднённые показания: {1} из {2}", series.Name, P.currUsersNum, P.maxUsersNum);
                        this.tooltip = new ToolTip();
                        tooltip.SetToolTip(mainChart, Info);
                        tooltip.Active = true;
                    }
                    else
                    {
                        string Info = series.Name;
                        string usrs = String.Format("Использовано {0} из {1} лицензий:\n\n", P.currUsersNum, P.maxUsersNum);
                        foreach (User user in P.Users)
                            usrs += string.Format("{0}\n", user.Name);
                        MessageBox.Show(usrs, Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonProductNames_Click(object sender, EventArgs e)
        {
            if(this.statesContainer != null)
            {
                NamesWindow win = new NamesWindow(this.statesContainer.States);
                win.Show();
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
    }    
}
