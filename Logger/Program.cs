using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

namespace LogWriter
{
    class Program
    {
        static string path = "\\\\venera\\autodesk_lic_status\\status_venera.txt";

        static void Main(string[] args)
        {
            DateTime currenttime = DateTime.Now;
            DateTime startTime = new DateTime(currenttime.Date.Ticks).AddHours(7);
            DateTime finishTime = new DateTime(currenttime.Date.Ticks).AddHours(19);
            if (currenttime >= startTime && currenttime <= finishTime)
            {
                new State(path);
            }
            else
                new DailyState();
        }
    }
}
