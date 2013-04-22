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
    public class DailyLogFile
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

        public DailyLogFile(DateTime Date)
        {
            if (Directory.Exists(PREFERENCES.DailyLogDirectoryPath))
            {
                this.date = Date;
                this.states = new List<State>();

                IEnumerable<string> files = Directory.EnumerateFiles(PREFERENCES.DailyLogDirectoryPath);
                foreach (string f in files)
                {
                    State S = State.Load(f);
                    this.states.Add(S);
                }
            }
        }
    }    
}
