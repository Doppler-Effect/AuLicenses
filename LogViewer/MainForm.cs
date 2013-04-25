using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

namespace LogViewer
{
    public partial class MainForm : Form
    {
        StatesContainer statesContainer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            this.statesContainer = new StatesContainer(PREFERENCES.LogDirectoryPath);
        }

        private void buttonOpenDaily_Click(object sender, EventArgs e)
        {
            this.statesContainer = new StatesContainer(PREFERENCES.DailyLogDirectoryPath);
            drawChart();
        }

        void drawChart()
        {
            foreach (string ID in this.statesContainer.AllProductIDs)
            {
                mainChart.ChartAreas[0].AxisY.Interval = 1;
                mainChart.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series(ID);
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                series.LabelToolTip = ID;
                series.LegendText = ID;
                foreach (State s in this.statesContainer.States)
                {
                    Product p = Utils.FindProduct(s, ID);
                    double y = p == null ? 0 : p.currUsers;
                    series.Points.AddXY(s.Datetime, y);
                }
                mainChart.Series.Add(series);
            }
        }
    }    
}
