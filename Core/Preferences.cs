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
        const string FILEPATH = "AULicUtil_pref.bin";

        public static string LogDirectoryPath
        {
            get 
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IPN License usage log");
                //return Path.Combine(Environment.GetLogicalDrives()[0], "IPN License usage log");
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
            if (File.Exists(FILEPATH))
            {
                PREFERENCES p = deserialize();
                this.filenames = p.filenames;
            }
            else
            {
                this.filenames = new List<string>();
            }
        }

        List<string> filenames;
        public List<string> Filenames
        {
            get
            {
                return this.filenames;
            }
        }

        public void AddFileName(string s)
        {
            if (!filenames.Contains(s))
            {
                this.filenames.Add(s);
                serialize(this);
            }
        }

        public void RemoveFileName(string s)
        {
            if (filenames.Contains(s))
            {
                this.filenames.Remove(s);
                serialize(this);
            }
        }

        public static void serialize(PREFERENCES data)
        {
            FileStream stream = File.Create(FILEPATH);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, data);
            stream.Close();
        }

        public static PREFERENCES deserialize()
        {
            PREFERENCES result;
            FileStream stream = File.OpenRead(FILEPATH);
            BinaryFormatter deserializer = new BinaryFormatter();
            result = (PREFERENCES)deserializer.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
