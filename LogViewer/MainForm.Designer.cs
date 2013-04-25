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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.groupBoxOpen = new System.Windows.Forms.GroupBox();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            // buttonOpen
            // 
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Location = new System.Drawing.Point(6, 19);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(135, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "за всё время";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // groupBoxOpen
            // 
            this.groupBoxOpen.Controls.Add(this.buttonOpenDaily);
            this.groupBoxOpen.Controls.Add(this.button1);
            this.groupBoxOpen.Controls.Add(this.buttonOpen);
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
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(165, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(607, 418);
            this.mainChart.TabIndex = 5;
            this.mainChart.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 442);
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
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.GroupBox groupBoxOpen;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
    }
}

