using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab_05_log_to_event_viewer
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application", "nice", EventLogEntryType.Error,42069,1234);
        }
    }
}
