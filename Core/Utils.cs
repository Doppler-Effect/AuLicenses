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

        public static List<string> FindAllProductIDs(this IEnumerable<State> states)
        {
            List<string> IDs = new List<string>();

            foreach (State s in states)
            {
                foreach (Product p in s.Products)
                {
                    if (!IDs.Contains(p.ID))
                    {
                        IDs.Add(p.ID);
                    }
                }
            }
            return IDs;
        }

        public static Product FindProductByName(this State s, string name)
        {
            Product result = null;
            foreach (Product p in s.Products)
            {
                if (p.ID.Contains(name))
                    result = p;
            }
            return result;
        }
    }
}
