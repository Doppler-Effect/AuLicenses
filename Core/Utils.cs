using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Core
{
    static class Utils
    {
        public static string ReplaceFilenameChars(this string name)
        {            
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '-');
            }
            return name;
        }
    }
}
