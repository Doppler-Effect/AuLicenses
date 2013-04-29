using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core
{
    public partial class NamesWindow : Form
    {
        
        public NamesWindow(List<State> states)
        {
            InitializeComponent();
        }

        public NamesWindow(List<Product> products)
        {
            InitializeComponent();
            FillGrid(products);
        }

        void FillGrid(List<Product> productList)
        {
            foreach (Product p in productList)
            {
                this.dataGridView1.Rows.Add();
            }
        }
    }
}
