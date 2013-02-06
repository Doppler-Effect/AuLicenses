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
            findActiveProducts();
        }

        void findActiveProducts()
        {
            products.Clear();
            FileStream stream = new FileStream(this.path, FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(stream);
            while (!file.EndOfStream)
            {
                string row = file.ReadLine();
                if (row.Contains("Users of") && row.Contains("Total of"))
                {
                    ProductTextRow protoProduct = new ProductTextRow(row);
                    if (protoProduct.CurrentUsers > 0)
                    {
                        this.fileOK = true;
                        products.Add(new Product(protoProduct, this));
                    }
                }
            }
            stream.Dispose();
        }        
        
        public List<user> getUserNames(ProductTextRow startRow)
        {
            List<user> result = new List<user>();
            if (fileOK)
            {
                FileStream stream = new FileStream(this.path, FileMode.Open, FileAccess.Read);
                StreamReader file = new StreamReader(stream);
                string row = null;
                while (!file.EndOfStream && row != startRow.SourceRow)
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
