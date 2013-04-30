using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Core
{
    static class ProductNamesContainer
    {
        static string filename
        {
            get { return Path.Combine(PREFERENCES.MainDirectoryPath, "ProductNames"); }
        }
        const char divider = '|';

        static Dictionary<string, string> productNames = new Dictionary<string, string>();

        public static Dictionary<string, string> ProductNames
        {
            get 
            {
                if (productNames.Count == 0)
                {
                    Load();
                    return productNames;
                }
                else
                    return productNames;
            }
        }

        public static void UpdateProductNames(Dictionary<string, string> input)
        {
            foreach (KeyValuePair<string, string> pair in input)
            {
                if (productNames.ContainsKey(pair.Key))
                    productNames[pair.Key] = pair.Value;
                else
                    productNames.Add(pair.Key, pair.Value);
            }
            Save();
        }

        static void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            FileStream stream = File.Create(filename);
            StreamWriter writer = new StreamWriter(stream);
            using (writer)
            {
                foreach (KeyValuePair<string, string> IdName in productNames)
                {
                    string key = IdName.Key.Replace(divider, '&');
                    string value = IdName.Value.Replace(divider, '&');
                    writer.WriteLine(string.Format("{0}{1}{2}", IdName.Key, divider, IdName.Value));
                }
            }
        }

        static void Load()
        {
            if (File.Exists(filename))
            {
                productNames.Clear();
                FileStream stream = File.OpenRead(filename);
                StreamReader reader = new StreamReader(stream);
                using (reader)
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] tokens = line.Split(divider);
                        productNames.Add(tokens[0], tokens[1]);
                    }
                }
            }
        }
    }
}
