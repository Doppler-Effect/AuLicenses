using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    [Serializable()]
    public class PREFERENCES
    {
        #region Singleton
        private static PREFERENCES instance;
        public static PREFERENCES Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PREFERENCES();
                }
                return instance;
            }
        }
        private PREFERENCES()
        {
            if (File.Exists(PREF_FILE_PATH))
                Load();         
            else
            {
                this.monitorFilenames = new List<string>();
                this.holidays = new List<DateTime>();
                this.productNames = new Dictionary<string, string>();
            }
        }
        #endregion

        private string PREF_FILE_PATH
        {
            get { return Path.Combine(MainDirectoryPath, "IPN_LicUtilPref.bin"); }
        }

        public string MainDirectoryPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPNLicenseUtil");
            }
        }

        public string LogDirectoryPath
        {
            get 
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPN License usage log");
            }
        }

        public string DailyLogDirectoryPath
        {
            get
            {
                return Path.Combine(LogDirectoryPath, "Daily");
            }
        }

        private List<DateTime> holidays;
        public List<DateTime> Holidays
        {
            get
            {
                return this.holidays;
            }
            set
            {
                this.holidays = value;
                this.Save();
            }
        }

        private Dictionary<string, string> productNames;
        public Dictionary<string, string> ProductNames
        {
            get { return this.productNames; }
        }        
        public void UpdateProductNames(Dictionary<string, string> input)
        {
            foreach (KeyValuePair<string, string> pair in input)
            {
                if (productNames.ContainsKey(pair.Key))
                    productNames[pair.Key] = pair.Value;
                else
                    productNames.Add(pair.Key, pair.Value);
            }
            Save();
        }

        List<string> monitorFilenames;
        public List<string> MonitorFilenames
        {
            get
            {
                return this.monitorFilenames;
            }
        }
        public void AddMonitorFileName(string s)
        {
            if (!monitorFilenames.Contains(s))
            {
                this.monitorFilenames.Add(s);
                Save();
            }
        }
        public void RemoveMonitorFileName(string s)
        {
            if (monitorFilenames.Contains(s))
            {
                this.monitorFilenames.Remove(s);
                Save();
            }
        }

        private void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(this.PREF_FILE_PATH));
            FileStream stream = File.Create(PREF_FILE_PATH);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, this);
            stream.Close();
        }

        private void Load()
        {
            PREFERENCES P;
            FileStream stream = File.OpenRead(PREF_FILE_PATH);
            BinaryFormatter deserializer = new BinaryFormatter();
            P = (PREFERENCES)deserializer.Deserialize(stream);
            stream.Close();

            this.monitorFilenames = P.monitorFilenames;
            this.holidays = P.holidays;
            this.productNames = P.productNames;
        }
    }
}
