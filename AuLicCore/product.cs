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

        List<user> users;
        public List<user> Users
        {
            get
            {
                return users;
            }
        }

        public Product(string row, licFile parentFile)
        //Users of 64300ACD_F:  (Total of 23 licenses issued;  Total of 19 licenses in use)
        {
            this.id = row.Trim().Split(' ')[2].Trim(':');
            int pos = row.IndexOf("Total of");
            this.maxusers = licFile.getNumberAfterPosition(pos, row);
            pos = row.LastIndexOf("Total of");
            this.currentusers = licFile.getNumberAfterPosition(pos, row);
            this.users = parentFile.getUserNames(row);
        }        
    }
}
