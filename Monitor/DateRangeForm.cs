using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace LogViewer
{
    public partial class DateRangeForm : Form
    {
        public YearAndMonth Result;

        public DateRangeForm(DateTime[] dates)
        {
            InitializeComponent();
            fillTreeView(dates);
        }

        private void fillTreeView(DateTime[] dates)
        {
            List<YearAndMonth> values = new List<YearAndMonth>();
            foreach (DateTime date in dates)
            {
                YearAndMonth ym = new YearAndMonth(date);
                if (!values.Contains<YearAndMonth>(ym))
                    values.Add(ym);
            }

            List<int> years = new List<int>();
            foreach (YearAndMonth ym in values)
            {
                if (!years.Contains(ym.year))
                {
                    treeView1.Nodes.Add(ym.year.ToString(), ym.year.ToString());
                    years.Add(ym.year);
                }
                TreeNode monthNode = new TreeNode(ym.month);
                monthNode.Tag = ym;
                treeView1.Nodes[ym.year.ToString()].Nodes.Add(monthNode);
            }
        }
        
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode.Tag != null)
            {
                Result = (YearAndMonth)selectedNode.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }    
}
