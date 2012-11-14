using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuLicCore
{
    public class Product
    {
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string ID
        {
            get
            {
                return id;
            }
        }

        int maxusers, currentusers;
        string name, id;

        public Product(string str)
        {

        }
    }
}
