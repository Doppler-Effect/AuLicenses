using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AuLicCore
{
    public class licFile
    {
        #region STATIC FIELDS

        public static int getNumberAfterPosition(int pos, string row)
        {
            if (pos != -1)
            {
                int result;
                string str = "";

                while (!char.IsNumber(row, pos))
                {
                    pos += 1;
                }
                do
                {
                    str += row[pos];
                    pos += 1;
                } while (char.IsNumber(row, pos));

                str = str.Trim();

                if (int.TryParse(str, out result))
                    return result;
                else
                    return 0;
            }
            else
                return 0;
        }

        #endregion

        public string Name
        {
            get
            {
                return name;
            }
        }
        string name, path;
        bool fileOK = false;
        List<Product> products = new List<Product>();
        public List<Product> Products
        {
            get
            {
                return products;
            }
        }

        public licFile(string name, string path)
        {
            this.path = path;
            this.name = name;
            fileOK = true;  //тут будет добавлена логика проверки наличия файла
            findActiveProducts();
        }

        void findActiveProducts()
        {
            products.Clear();
            if (fileOK)
            {
                FileStream stream = new FileStream(this.path, FileMode.Open, FileAccess.Read);
                StreamReader file = new StreamReader(stream);
                while (!file.EndOfStream)
                {
                    string row = file.ReadLine();
                    if (row.Contains("Users of") && this.ProductActive(row))
                    {
                        products.Add(new Product(row, this));
                    }
                }
                stream.Dispose();
            }
        }

        bool ProductActive(string row)
        {
            if (row.Contains("Total of"))
            {
                int licCount = getNumberAfterPosition(row.LastIndexOf("Total of"), row);
                if (licCount > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        
        public List<user> getUserNames(string startRow)
        {
            List<user> result = new List<user>();
            if (fileOK)
            {
                FileStream stream = new FileStream(this.path, FileMode.Open, FileAccess.Read);
                StreamReader file = new StreamReader(stream);
                string row = null;
                while (!file.EndOfStream && row != startRow)
                {
                    row = file.ReadLine();
                }
                do
                {
                    row = file.ReadLine();
                    if (row.Contains("start"))
                        result.Add(new user(getUserNameFromString(row)));                    
                } while (!file.EndOfStream && !row.Contains("Users of"));
                stream.Dispose();
            }
            return result;
        }

        string getUserNameFromString(string row)
        {
            string[] tokens = row.Trim().Split(' ');
            return tokens[0];
        }
    }
}
