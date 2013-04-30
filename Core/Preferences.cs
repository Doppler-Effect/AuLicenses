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
        private string PREF_FILE_PATH
        {
            get { return Path.Combine(MainDirectoryPath, "IPN_LicUtilPref.bin"); }
        }

        public static string MainDirectoryPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPNLicenseUtil");
            }
        }

        public static string LogDirectoryPath
        {
            get 
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPN License usage log");
            }
        }

        public static string DailyLogDirectoryPath
        {
            get
            {
                return Path.Combine(LogDirectoryPath, "Daily");
            }
        }
        
        public PREFERENCES()
        {
            if (File.Exists(PREF_FILE_PATH))
            {
                PREFERENCES p = Load();
                this.monitorFilenames = p.monitorFilenames;
            }
            else
            {
                this.monitorFilenames = new List<string>();
            }
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

        private PREFERENCES Load()
        {
            PREFERENCES result;
            FileStream stream = File.OpenRead(PREF_FILE_PATH);
            BinaryFormatter deserializer = new BinaryFormatter();
            result = (PREFERENCES)deserializer.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
