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
            this.buttonOpenDay = new System.Windows.Forms.Button();
            this.buttonOpenToday = new System.Windows.Forms.Button();
            this.groupBoxOpen = new System.Windows.Forms.GroupBox();
            this.groupBoxNormalized = new System.Windows.Forms.GroupBox();
            this.radioButtonHolidays = new System.Windows.Forms.RadioButton();
            this.radioButtonWorkDays = new System.Windows.Forms.RadioButton();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.productsListBox = new System.Windows.Forms.CheckedListBox();
            this.buttonProductNames = new System.Windows.Forms.Button();
            this.groupBoxOpen.SuspendLayout();
            this.groupBoxNormalized.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenDay
            // 
            this.buttonOpenDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenDay.Location = new System.Drawing.Point(6, 118);
            this.buttonOpenDay.Name = "buttonOpenDay";
            this.buttonOpenDay.Size = new System.Drawing.Size(135, 23);
            this.buttonOpenDay.TabIndex = 3;
            this.buttonOpenDay.Text = "За конкретные дни";
            this.buttonOpenDay.UseVisualStyleBackColor = true;
            this.buttonOpenDay.Click += new System.EventHandler(this.buttonOpenDay_Click);
            // 
            // buttonOpenToday
            // 
            this.buttonOpenToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenToday.Location = new System.Drawing.Point(6, 89);
            this.buttonOpenToday.Name = "buttonOpenToday";
            this.buttonOpenToday.Size = new System.Drawing.Size(135, 23);
            this.buttonOpenToday.TabIndex = 2;
            this.buttonOpenToday.Text = "За сегодня";
            this.buttonOpenToday.UseVisualStyleBackColor = true;
            this.buttonOpenToday.Click += new System.EventHandler(this.buttonOpenToday_Click);
            // 
            // groupBoxOpen
            // 
            this.groupBoxOpen.Controls.Add(this.groupBoxNormalized);
            this.groupBoxOpen.Controls.Add(this.buttonOpenToday);
            this.groupBoxOpen.Controls.Add(this.buttonOpenDay);
            this.groupBoxOpen.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOpen.Name = "groupBoxOpen";
            this.groupBoxOpen.Size = new System.Drawing.Size(147, 146);
            this.groupBoxOpen.TabIndex = 4;
            this.groupBoxOpen.TabStop = false;
            this.groupBoxOpen.Text = "Загрузить информацию";
            // 
            // groupBoxNormalized
            // 
            this.groupBoxNormalized.Controls.Add(this.radioButtonHolidays);
            this.groupBoxNormalized.Controls.Add(this.radioButtonWorkDays);
            this.groupBoxNormalized.Location = new System.Drawing.Point(6, 19);
            this.groupBoxNormalized.Name = "groupBoxNormalized";
            this.groupBoxNormalized.Size = new System.Drawing.Size(135, 67);
            this.groupBoxNormalized.TabIndex = 4;
            this.groupBoxNormalized.TabStop = false;
            this.groupBoxNormalized.Text = "В среднем за:";
            // 
            // radioButtonHolidays
            // 
            this.radioButtonHolidays.AutoSize = true;
            this.radioButtonHolidays.Location = new System.Drawing.Point(6, 42);
            this.radioButtonHolidays.Name = "radioButtonHolidays";
            this.radioButtonHolidays.Size = new System.Drawing.Size(76, 17);
            this.radioButtonHolidays.TabIndex = 1;
            this.radioButtonHolidays.Text = "выходные";
            this.radioButtonHolidays.UseVisualStyleBackColor = true;
            this.radioButtonHolidays.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonHolidays_MouseClick);
            // 
            // radioButtonWorkDays
            // 
            this.radioButtonWorkDays.AutoSize = true;
            this.radioButtonWorkDays.Location = new System.Drawing.Point(6, 19);
            this.radioButtonWorkDays.Name = "radioButtonWorkDays";
            this.radioButtonWorkDays.Size = new System.Drawing.Size(87, 17);
            this.radioButtonWorkDays.TabIndex = 0;
            this.radioButtonWorkDays.Text = "рабочие дни";
            this.radioButtonWorkDays.UseVisualStyleBackColor = true;
            this.radioButtonWorkDays.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonWorkDays_MouseClick);
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
            this.mainChart.Size = new System.Drawing.Size(607, 538);
            this.mainChart.TabIndex = 5;
            this.mainChart.TabStop = false;
            this.mainChart.Text = "chart1";
            this.mainChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainChart_MouseClick);
            // 
            // productsListBox
            // 
            this.productsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productsListBox.CheckOnClick = true;
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(12, 164);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(147, 257);
            this.productsListBox.TabIndex = 6;
            this.productsListBox.TabStop = false;
            this.productsListBox.SelectedIndexChanged += new System.EventHandler(this.productsListBox_SelectedIndexChanged);
            // 
            // buttonProductNames
            // 
            this.buttonProductNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonProductNames.Location = new System.Drawing.Point(12, 527);
            this.buttonProductNames.Name = "buttonProductNames";
            this.buttonProductNames.Size = new System.Drawing.Size(147, 23);
            this.buttonProductNames.TabIndex = 7;
            this.buttonProductNames.Text = "Названия программ...";
            this.buttonProductNames.UseVisualStyleBackColor = true;
            this.buttonProductNames.Click += new System.EventHandler(this.buttonProductNames_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonProductNames);
            this.Controls.Add(this.productsListBox);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.groupBoxOpen);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Использование лицензий в ЗАО \"ИПН\"";
            this.groupBoxOpen.ResumeLayout(false);
            this.groupBoxNormalized.ResumeLayout(false);
            this.groupBoxNormalized.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenDay;
        private System.Windows.Forms.Button buttonOpenToday;
        private System.Windows.Forms.GroupBox groupBoxOpen;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.CheckedListBox productsListBox;
        private System.Windows.Forms.RadioButton radioButtonHolidays;
        private System.Windows.Forms.RadioButton radioButtonWorkDays;
        private System.Windows.Forms.GroupBox groupBoxNormalized;
        private System.Windows.Forms.Button buttonProductNames;
    }
}

