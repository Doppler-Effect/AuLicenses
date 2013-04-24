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

        List<State> states;
        public List<State> States
        {
            get { return states; }
        }

        public override string FilePath
        {
            get { return Path.Combine(PREFERENCES.LogDirectoryPath, this.date.ToShortDateString() + FILEEXTENSION); }
        }

        public DailyState()
        {
            this.FILEEXTENSION = ".ipndaily";

            if (Directory.Exists(PREFERENCES.DailyLogDirectoryPath))
            {
                this.date = DateTime.Now.Date;
                this.states = new List<State>();

                IEnumerable<string> files = Directory.EnumerateFiles(PREFERENCES.DailyLogDirectoryPath);
                foreach (string f in files)
                {
                    State S = (State)State.Load(f);
                    this.states.Add(S);
                }
                
                this.Save(this.FilePath);

                Directory.Delete(PREFERENCES.DailyLogDirectoryPath, true);
            }
        }        
    }    
}
