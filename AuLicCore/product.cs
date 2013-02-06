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
        public int maxUsers
        {
            get
            {
                return this.maxusers;
            }
        }
        public int currUsers
        {
            get
            {
                return this.users.Count;
            }
        }

        int maxusers;
        string name, id;

        List<user> users;
        public List<user> Users
        {
            get
            {
                return users;
            }
        }

        List<Product> children;


        public Product(ProductTextRow row, licFile parentFile)
        //Users of 64300ACD_F:  (Total of 23 licenses issued;  Total of 19 licenses in use)
        {
            this.id = row.ProductID;
            this.maxusers = row.MaxUsers;
            this.users = parentFile.getUserNames(row);
        }        
    }
}
