using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using Core;

namespace UsageLogger
{
    public partial class UsageLogger : ServiceBase
    {
        public UsageLogger()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("IPNUsageLoggerSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "IPNUsageLoggerSource", "IPNUsageLoggerLog");
            }
            eventLog1.Source = "IPNUsageLoggerSource";
            eventLog1.Log = "IPNUsageLoggerLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Work began");
            State stt = new State("\\\\venera\\autodesk_lic_status\\status_venera.txt");
        }

        protected override void OnContinue()
        {
            //State stt = new State("\\\\venera\\autodesk_lic_status\\status_venera.txt");
        }

        protected override void OnStop()
        {
        }
    }
}
