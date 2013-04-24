using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    [Serializable()]
    public class State : SerializeableClass
    {
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

        public override string FilePath
        {
            get { return Path.Combine(PREFERENCES.DailyLogDirectoryPath, this.datetime.ToString().ReplaceFilenameChars() + FILEEXTENSION); }
        }

        public State(string licfilepath)
        {
            this.FILEEXTENSION = ".ipnlicstate";

            if(File.Exists(licfilepath))
            {                
                LicFile file = new LicFile("file", licfilepath);
                this.products = file.Products;
                this.datetime = DateTime.Now;                
                
                this.Save(this.FilePath);
            }
        } 
    }
}
