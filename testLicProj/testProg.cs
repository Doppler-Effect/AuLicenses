using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace testLicProj
{
    class testProg
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new State("\\\\venera\\autodesk_lic_status\\status_venera.txt");
                System.Threading.Thread.Sleep(1000);
            }
            new DailyState();
        }
    }
}
