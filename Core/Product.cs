using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    [Serializable()]
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
        public int maxUsersNum
        {
            get
            {
                return this.maxusers;
            }
        }
        public double currUsersNum
        {
            get
            {
                if (IsNormalized)
                    return this.mergedUserNum;
                else
                    return this.users.Count;
            }
        }
        bool isNormalized;
        public bool IsNormalized
        {
            get
            {
                return this.isNormalized;
            }
        }

        int maxusers;
        double mergedUserNum;
        string name, id;

        List<User> users;
        public List<User> Users
        {
            get
            {
                return users;
            }
        }

        //List<Product> children;

        public Product(ProductTextRow row, LicFile parentFile)
        //Users of 64300ACD_F:  (Total of 23 licenses issued;  Total of 19 licenses in use)
        {
            this.id = row.ProductID;
            this.maxusers = row.MaxUsers;
            this.users = parentFile.getUserNames(row);
            this.isNormalized = false;
        }

        public void Merge(Product newP)
        {
            if (newP != null)
            {
                this.mergedUserNum = (this.currUsersNum + newP.currUsersNum) / 2;
                this.users.Clear();
                this.isNormalized = true;
            }
        }
    }
}
