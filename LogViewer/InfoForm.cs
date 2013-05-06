using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class InfoForm : Form
    {
        public InfoForm(string Caption, string text, Point location, bool CloseButton = false)
        {
            InitializeComponent();
            this.Text = Caption;
            this.label.Text = text;
            this.Location = location;
            this.ControlBox = CloseButton;
        }

        private void InfoForm_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
        }

        //this.MouseLeave -= InfoForm_MouseLeave;
        //this.ControlBox = true;
    }
}
