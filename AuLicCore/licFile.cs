using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AuLicCore
{
    class licFile
    {
        public string Name
        {
            get
            {
                return name;
            }
        }
        string name, path;

        public licFile(string name, string path)
        {
            this.path = "D:\\Dropbox\\work\\status_venera.txt";
            this.name = name;
        }

        public List<Product> findActiveProducts()
        {
            List<Product> result = new List<Product>();

            FileStream stream = new FileStream(this.path, FileMode.Open);
            StreamReader file = new StreamReader(stream);
            while (!file.EndOfStream)
            {
                string row = file.ReadLine();
                
            }
        }
        
    }
}
