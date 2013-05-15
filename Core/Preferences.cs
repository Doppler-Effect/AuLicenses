using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            get { return Path.Combine(MainPath, "IPN_LicUtilPref.bin"); }
        }

        public string MainPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPNLicenseUtil");
            }
        }

        private string logDirectoryPath;
        public string LogDirectoryPath
        {
            get 
            {
                if (this.logDirectoryPath != null && Directory.Exists(logDirectoryPath))
                    return this.logDirectoryPath;

                string result = PromptForDirectory();
                if (result != null)
                {
                    this.logDirectoryPath = result;
                    this.Save();
                    return result;
                }
                else
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPN License usage log");
            }
        }
        public void SetLogDirectoryPath()
        {
            string path = this.PromptForDirectory();
            if (!String.IsNullOrEmpty(path))
            {
                this.logDirectoryPath = path;
                this.Save();
            }
        }
        private string PromptForDirectory()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = false;
            dialog.Filter = String.Format("Daily log files (*{0})|*{0}", DailyState.FILEEXTENSION);
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
                return Path.GetDirectoryName(dialog.FileName);
            else
                return null;
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
            this.logDirectoryPath = P.logDirectoryPath;
        }
    }
}
