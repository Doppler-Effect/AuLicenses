using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AuLicCore
{
    public class licFile
    {
        public string Name
        {
            get
            {
                return name;
            }
        }
        string name, path;
        bool fileOK = false;

        public licFile(string name, string path)
        {
            this.path = "D:\\Dropbox\\work\\status_venera.txt";
            this.name = name;
            fileOK = true;
        }

        public List<Product> findActiveProducts()
        {
            if (fileOK)
            {
                List<Product> result = new List<Product>();

                FileStream stream = new FileStream(this.path, FileMode.Open);
                StreamReader file = new StreamReader(stream);
                while (!file.EndOfStream)
                {
                    string row = file.ReadLine();
                    if (row.Contains("Users of") && this.isProductActive(row))
                    {
                        result.Add(new Product(row));
                    }
                }
                stream.Close();
                return result;
            }
            else
                return null;
        }

        bool isProductActive(string row)
        {
            int pos = row.LastIndexOf("Total of");
            int licCount = getNumberFromPosition(pos, row);
            if (licCount > 0)
                return true;
            else
                return false;
        }

        public static int getNumberFromPosition(int pos, string row)
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
            } while (char.IsNumber(row, pos)) ;

            str = str.Trim();

            if(int.TryParse(str, out result))
                return result;
            else
                return 0;
        }

    }
}
