using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    /// <summary>
    /// "Снимок" состояния lic-файла в определённое время.
    /// </summary>
    [Serializable()]
    public class State : SerializeableClass, IComparable<State>
    {
        DateTime datetime;        
        public DateTime Datetime
        {
            get { return datetime; }
        }

        public const string FILEEXTENSION = ".ipnlicstate";

        List<Product> products;
        public List<Product> Products
        {
            get { return products; }
        }

        public override string FilePath
        {
            get { return Path.Combine(PREFERENCES.DailyLogDirectoryPath, this.datetime.ToString().ReplaceFilenameChars() + FILEEXTENSION); }
        }

        public int CompareTo(State state)
        {
            if (state != null)
            {
                return this.Datetime.CompareTo(state.Datetime);
            }
            else
                return 1;
        }

        public State(string licfilepath)
        {
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
