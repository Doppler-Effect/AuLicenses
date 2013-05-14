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

    public class YearAndMonth : IEquatable<YearAndMonth>
    {
        private readonly string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
        }

        public int year
        {
            get { return this.date.Year; }
        }
        public string month
        {
            get { return this.months[this.date.Month - 1]; }
        }

        public YearAndMonth(DateTime d)
        {
            this.date = d;
        }

        public bool Equals(YearAndMonth X)
        {
            if (X == null)
                return false;
            if (X.year == this.year && X.month == this.month)
                return true;
            else
                return false;
        }  
    }
}
