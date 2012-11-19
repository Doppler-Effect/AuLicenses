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
            file.findActiveProducts();
        }
    }
}
