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
        /// <summary>
        /// Отображает, был ли этот State слит с другим.
        /// </summary>
        private bool isMerged = false;
        public bool IsMerged
        {
            get { return isMerged; }
            set { isMerged = value; }
        }

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
                int result = this.Datetime.CompareTo(state.Datetime);
                return result;
            }
            else
                return 1;
        }
        public static int CompareByTime(State x, State y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare
                    DateTime now = new DateTime(DateTime.Now.Date.Ticks);
                    DateTime dtX = now.AddHours(x.Datetime.Hour).AddMinutes(x.Datetime.Minute).AddSeconds(x.Datetime.Second);
                    DateTime dtY = now.AddHours(y.Datetime.Hour).AddMinutes(y.Datetime.Minute).AddSeconds(y.Datetime.Second);
                    int result = dtX.CompareTo(dtY);
                    return result;
                }
            }
        }

        public State(string licfilepath, bool Save = true)
        {
            if(File.Exists(licfilepath))
            {                
                LicFile file = new LicFile("file", licfilepath);
                this.products = file.Products;
                this.datetime = DateTime.Now;                
                
                if(Save)
                    this.Save(this.FilePath);
            }
        }        

        public void Merge(State newState)
        {
            int dHour = Math.Abs(this.Datetime.Hour - newState.Datetime.Hour);
            int dMinute = Math.Abs(this.Datetime.Minute - newState.Datetime.Minute);

            if (dHour == 0 && dMinute < 3)
            {
                foreach (string pName in Core.Utils.FindAllProductIDs(new State[] { this, newState }))
                {
                    Product thisP, newP;
                    thisP = this.FindProductByName(pName);
                    newP = newState.FindProductByName(pName);

                    if (thisP != null)
                    {
                        thisP.Merge(newP);
                    }
                    else
                        this.products.Add(newP);
                }
                newState.IsMerged = true;
            }
        }        
    }
}
