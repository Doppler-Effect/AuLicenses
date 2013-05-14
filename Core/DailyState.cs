using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    /// <summary>
    /// Хранилище для данных за день работы. Содержит таймстэмп дня и массив State-ов за этот день.
    /// </summary>
    [Serializable()]
    public class DailyState : SerializeableClass
    {
        DateTime date;
        public DateTime Date
        {
            get { return date; }
        }

        public const string FILEEXTENSION = ".ipndaily";

        public bool IsHoliday
        {
            get
            {
                if (PREFERENCES.Instance.Holidays != null && PREFERENCES.Instance.Holidays.Contains<DateTime>(this.date.Date))
                    return true;
                else
                    return false;
            }
        }

        List<State> states;
        public List<State> States
        {
            get { return states; }
        }

        public override string FilePath
        {
            get { return Path.Combine(PREFERENCES.Instance.LogDirectoryPath, this.reverseDateString + FILEEXTENSION); }
        }

        private string reverseDateString
        {
            get
            {
                StringBuilder s = new StringBuilder();
                s.Append(this.date.Year);
                s.Append('.');
                string month = this.date.Month.ToString();
                if (month.Length == 1)
                    month = month.Insert(0, "0");
                s.Append(month);
                s.Append('.');
                s.Append(this.date.Day);

                return s.ToString();
            }
        }

        public DailyState()
        {
            if (Directory.Exists(PREFERENCES.Instance.DailyLogDirectoryPath))
            {
                this.date = DateTime.Now.Date;
                this.states = new List<State>();

                IEnumerable<string> files = Directory.EnumerateFiles(PREFERENCES.Instance.DailyLogDirectoryPath);
                foreach (string f in files)
                {
                    State S = (State)State.Load(f);
                    this.states.Add(S);
                }
                
                this.Save(this.FilePath);

                Directory.Delete(PREFERENCES.Instance.DailyLogDirectoryPath, true);
            }
        }        
    }    
}
