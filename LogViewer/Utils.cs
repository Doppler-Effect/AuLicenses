using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;

namespace LogViewer
{
    static class Utils
    {
        public static Product FindProduct(State s, string name)
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
