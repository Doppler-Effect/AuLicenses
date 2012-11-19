using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AuLicCore;

namespace testLicProj
{
    class testProg
    {
        static void Main(string[] args)
        {
            licFile file = new licFile("File1", "D:\\Dropbox\\work\\status_venera.txt");
            foreach (Product pr in file.Products)
            {
                Console.WriteLine("Пользователи продукта {0}", pr.ID);
                foreach (user usr in pr.Users)
                {
                    Console.WriteLine("   {0}", usr.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
