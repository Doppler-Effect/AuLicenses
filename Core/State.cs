using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    [Serializable()]
    public class State
    {
        const string FILEEXTENSION = ".ipnlicstate";

        DateTime datetime;        
        public DateTime Datetime
        {
            get { return datetime; }
        }

        List<Product> products;
        public List<Product> Products
        {
            get { return products; }
        }

        public State(string licfilepath)
        {     
            if(File.Exists(licfilepath))
            {                
                LicFile file = new LicFile("file", licfilepath);
                this.products = file.Products;
                this.datetime = DateTime.Now;

                string filePath = Path.Combine(PREFERENCES.DailyLogDirectoryPath, this.datetime.ToString() + ".bin"/*FILEEXTENSION*/);
                this.Save(filePath);
            }
        } 

        public void Save(string filePath)
        {
            FileStream stream = File.Create(filePath);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, this);
            stream.Close();
        }

        public static State Load(string path)
        {
            State result;
            FileStream stream = File.OpenRead(path);
            BinaryFormatter deserializer = new BinaryFormatter();
            result = (State)deserializer.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
