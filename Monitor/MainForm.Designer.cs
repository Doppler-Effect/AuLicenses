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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.усреднённыеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holidaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setHolidaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusPath = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.mainChart.Location = new System.Drawing.Point(152, 27);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(620, 523);
            this.mainChart.TabIndex = 5;
            this.mainChart.TabStop = false;
            this.mainChart.Text = "chart1";
            this.mainChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainChart_MouseClick);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(134, 511);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.усреднённыеДанныеToolStripMenuItem,
            this.todayToolStripMenuItem,
            this.customDaysToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            // 
            // усреднённыеДанныеToolStripMenuItem
            // 
            this.усреднённыеДанныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workDaysToolStripMenuItem,
            this.holidaysToolStripMenuItem});
            this.усреднённыеДанныеToolStripMenuItem.Name = "усреднённыеДанныеToolStripMenuItem";
            this.усреднённыеДанныеToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.усреднённыеДанныеToolStripMenuItem.Text = "Усреднённые данные";
            // 
            // workDaysToolStripMenuItem
            // 
            this.workDaysToolStripMenuItem.Name = "workDaysToolStripMenuItem";
            this.workDaysToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.workDaysToolStripMenuItem.Text = "За рабочие дни";
            this.workDaysToolStripMenuItem.Click += new System.EventHandler(this.workDaysToolStripMenuItem_Click);
            // 
            // holidaysToolStripMenuItem
            // 
            this.holidaysToolStripMenuItem.Name = "holidaysToolStripMenuItem";
            this.holidaysToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.holidaysToolStripMenuItem.Text = "За выходные";
            this.holidaysToolStripMenuItem.Click += new System.EventHandler(this.holidaysToolStripMenuItem_Click);
            // 
            // todayToolStripMenuItem
            // 
            this.todayToolStripMenuItem.Name = "todayToolStripMenuItem";
            this.todayToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.todayToolStripMenuItem.Text = "За сегодня";
            this.todayToolStripMenuItem.Click += new System.EventHandler(this.todayToolStripMenuItem_Click);
            // 
            // customDaysToolStripMenuItem
            // 
            this.customDaysToolStripMenuItem.Name = "customDaysToolStripMenuItem";
            this.customDaysToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.customDaysToolStripMenuItem.Text = "За конкретные дни";
            this.customDaysToolStripMenuItem.Click += new System.EventHandler(this.customDaysToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.usersToolStripMenuItem.Text = "По пользователям";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setHolidaysToolStripMenuItem,
            this.programNamesToolStripMenuItem,
            this.logPathToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // setHolidaysToolStripMenuItem
            // 
            this.setHolidaysToolStripMenuItem.Name = "setHolidaysToolStripMenuItem";
            this.setHolidaysToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.setHolidaysToolStripMenuItem.Text = "Выходные дни...";
            this.setHolidaysToolStripMenuItem.Click += new System.EventHandler(this.setHolidaysToolStripMenuItem_Click);
            // 
            // programNamesToolStripMenuItem
            // 
            this.programNamesToolStripMenuItem.Name = "programNamesToolStripMenuItem";
            this.programNamesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.programNamesToolStripMenuItem.Text = "Названия программ...";
            this.programNamesToolStripMenuItem.Click += new System.EventHandler(this.programNamesToolStripMenuItem_Click);
            // 
            // logPathToolStripMenuItem
            // 
            this.logPathToolStripMenuItem.Name = "logPathToolStripMenuItem";
            this.logPathToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.logPathToolStripMenuItem.Text = "Путь к логам...";
            this.logPathToolStripMenuItem.Click += new System.EventHandler(this.logPathToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusPath
            // 
            this.toolStripStatusPath.Name = "toolStripStatusPath";
            this.toolStripStatusPath.Size = new System.Drawing.Size(738, 17);
            this.toolStripStatusPath.Spring = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Использование лицензий в ЗАО \"ИПН\"";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem усреднённыеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holidaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHolidaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logPathToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPath;
    }
}

