using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        List<Product> findActiveProducts()
        {

        }
    }
}
