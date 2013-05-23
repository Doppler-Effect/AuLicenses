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
    public partial class HolidaysSelector : Form
    {
        public HolidaysSelector()
        {
            InitializeComponent();
            this.monthCalendar1.BoldedDates = Core.PREFERENCES.Instance.Holidays.ToArray<DateTime>();
            if (monthCalendar1.BoldedDates == null || monthCalendar1.BoldedDates.Count() == 0)
                monthCalendar1.BoldedDates = this.Weekends;
        }

        DateTime[] Weekends
        {
            get
            {
                List<DateTime> result = new List<DateTime>();
                DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime finish = start.AddYears(10);
                for (DateTime date = start; date < finish; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                        result.Add(date);
                }
                return result.ToArray<DateTime>();
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            List<DateTime> bolded = monthCalendar1.BoldedDates.ToList<DateTime>();

            DateTime start = monthCalendar1.SelectionRange.Start;
            DateTime end = monthCalendar1.SelectionRange.End;

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                if (bolded.Contains(date))
                {                    
                    bolded.Remove(date);
                }
                else
                {
                    bolded.Add(date);
                }
            }

            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.BoldedDates = bolded.ToArray<DateTime>();
            monthCalendar1.UpdateBoldedDates();
            Core.PREFERENCES.Instance.Holidays = bolded;
        }
        
        private void HolidaysSelector_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKey(e.KeyCode);
        }

        private void monthCalendar1_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKey(e.KeyCode);
        }

        private void CheckKey(Keys code)
        {
            if (code == Keys.Escape)
            {
                if(MessageBox.Show("Удалить все данные из календаря?", "Внимание!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    monthCalendar1.RemoveAllBoldedDates();
                    monthCalendar1.BoldedDates = this.Weekends.ToArray<DateTime>();
                    Core.PREFERENCES.Instance.Holidays = monthCalendar1.BoldedDates.ToList<DateTime>();
                }
            }            
        }
    }
}
