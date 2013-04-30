using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Core
{
    public static class Utils
    {
        public static string ReplaceFilenameChars(this string name)
        {            
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '-');
            }
            return name;
        }

        public static List<string> FindAllProductNames(this IEnumerable<State> states)
        {
            List<Product> products = states.FindAllProducts();
            List<string> Names = new List<string>();

            foreach (Product P in products)
                Names.Add(P.Name);

            return Names;
        }

        public static List<Product> FindAllProducts(this IEnumerable<State> states)
        {
            List<Product> products = new List<Product>();

            foreach (State s in states)
            {
                foreach (Product p in s.Products)
                {
                    if (!products.Contains(p))
                    {
                        products.Add(p);
                    }
                }
            }
            return products;
        }

        public static Product FindProductByName(this State s, string name)
        {
            Product result = null;
            foreach (Product p in s.Products)
            {
                if (p.Name == name)
                    result = p;
            }
            return result;
        }
    }
}
