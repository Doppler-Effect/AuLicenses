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

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpenAll_Click(object sender, EventArgs e)
        {
            drawProductList(PREFERENCES.LogDirectoryPath);
        }

        private void buttonOpenDaily_Click(object sender, EventArgs e)
        {
            drawProductList(PREFERENCES.DailyLogDirectoryPath);
        }

        private void productsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawChart();
        }

        void drawProductList(string DirectoryPath)
        {
            this.productsListBox.Items.Clear();
            mainChart.Series.Clear();
            this.statesContainer = new StatesContainer(DirectoryPath);
            if (this.statesContainer.States != null)
            {
                foreach (string ID in this.statesContainer.AllProductIDs)
                {
                    this.productsListBox.Items.Add(ID, true);
                    drawChart();
                }
            }
        }

        void drawChart()
        {
            mainChart.Series.Clear();
            foreach (string ID in this.productsListBox.CheckedItems)
            {
                ChartArea area = mainChart.ChartAreas[0];
                area.AxisY.Interval = 1;
                area.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                area.AxisX.Title = "Время";
                area.AxisY.Title = "Количество лицензий";

                Series series = new Series(ID);
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                series.BorderWidth = 5;
                series.LegendText = ID;
                foreach (State s in this.statesContainer.States)
                {
                    Product p = s.FindProduct(ID);
                    double y = p == null ? 0 : p.currUsers;
                    series.Points.AddXY(s.Datetime, y);
                }
                mainChart.Series.Add(series);
            }
        }

        
    }    
}
