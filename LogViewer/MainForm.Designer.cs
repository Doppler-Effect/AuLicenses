namespace LogViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonOpenDaily = new System.Windows.Forms.Button();
            this.buttonOpenAll = new System.Windows.Forms.Button();
            this.groupBoxOpen = new System.Windows.Forms.GroupBox();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.productsListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBoxOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(6, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Обзор...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonOpenDaily
            // 
            this.buttonOpenDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDaily.Location = new System.Drawing.Point(6, 48);
            this.buttonOpenDaily.Name = "buttonOpenDaily";
            this.buttonOpenDaily.Size = new System.Drawing.Size(135, 23);
            this.buttonOpenDaily.TabIndex = 2;
            this.buttonOpenDaily.Text = "за день";
            this.buttonOpenDaily.UseVisualStyleBackColor = true;
            this.buttonOpenDaily.Click += new System.EventHandler(this.buttonOpenDaily_Click);
            // 
            // buttonOpenAll
            // 
            this.buttonOpenAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenAll.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenAll.Name = "buttonOpenAll";
            this.buttonOpenAll.Size = new System.Drawing.Size(135, 23);
            this.buttonOpenAll.TabIndex = 1;
            this.buttonOpenAll.Text = "за всё время";
            this.buttonOpenAll.UseVisualStyleBackColor = true;
            this.buttonOpenAll.Click += new System.EventHandler(this.buttonOpenAll_Click);
            // 
            // groupBoxOpen
            // 
            this.groupBoxOpen.Controls.Add(this.buttonOpenDaily);
            this.groupBoxOpen.Controls.Add(this.button1);
            this.groupBoxOpen.Controls.Add(this.buttonOpenAll);
            this.groupBoxOpen.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOpen.Name = "groupBoxOpen";
            this.groupBoxOpen.Size = new System.Drawing.Size(147, 108);
            this.groupBoxOpen.TabIndex = 4;
            this.groupBoxOpen.TabStop = false;
            this.groupBoxOpen.Text = "Загрузить информацию";
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.BorderColor = System.Drawing.Color.DarkGray;
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(165, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(607, 418);
            this.mainChart.TabIndex = 5;
            this.mainChart.TabStop = false;
            this.mainChart.Text = "chart1";
            // 
            // productsListBox
            // 
            this.productsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.productsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productsListBox.CheckOnClick = true;
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(12, 126);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(147, 272);
            this.productsListBox.TabIndex = 6;
            this.productsListBox.TabStop = false;
            this.productsListBox.SelectedIndexChanged += new System.EventHandler(this.productsListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.productsListBox);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.groupBoxOpen);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBoxOpen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOpenDaily;
        private System.Windows.Forms.Button buttonOpenAll;
        private System.Windows.Forms.GroupBox groupBoxOpen;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.CheckedListBox productsListBox;
    }
}

