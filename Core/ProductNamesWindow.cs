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
    public partial class ProductNamesWindow : Form
    {
        public ProductNamesWindow(List<State> states)
        {
            InitializeComponent();
            List<Product> products = states.FindAllProducts();
            FillGrid(products);
        }

        public ProductNamesWindow(List<Product> products)
        {
            InitializeComponent();
            FillGrid(products);
        }

        public ProductNamesWindow(List<string> idS)
        {
            InitializeComponent();
            FillGrid(idS);
        }

        void FillGrid(List<Product> products)
        {
            List<string> IDs = new List<string>();
            foreach (Product P in products)
            {
                if (!IDs.Contains(P.ID))
                    IDs.Add(P.ID);
            }
            FillGrid(IDs);
        }

        void FillGrid(List<string> idList)
        {           
            foreach (string id in idList)
            {
                string name = null;
                if(PREFERENCES.Instance.ProductNames.ContainsKey(id))
                    name = PREFERENCES.Instance.ProductNames[id];
                this.dataGridView1.Rows.Add(id, name);
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Dictionary<string, string> names = new Dictionary<string, string>();
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {                    
                    if (row.Cells[1].Value != null)
                    {
                        string name = row.Cells[1].Value.ToString();
                        string id = row.Cells[0].Value.ToString();
                        names.Add(id, name);
                    }
                }

                if (names.Count != 0)
                {
                    PREFERENCES.Instance.UpdateProductNames(names);
                }
                this.Close();
            }
        }
    }
}
