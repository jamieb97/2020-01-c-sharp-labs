using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace lab_04_debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@"c:\log\log.dat", "");
            

            int x = 10;
            x = x + 10;
            int y = x * x;
            Console.WriteLine(x);
            Console.WriteLine(y);
            for(int i = 0; i < 10; i++)
            {   
                Console.WriteLine(i);
                Trace.WriteLine($"Trace WirteLine {i}");
                Debug.WriteLine($"Debug writeline {i}");
                Debug.WriteLineIf(i == 6, "hey, i is 6");
                File.AppendAllText(@"c:\log\log.dat", $"\nLogging i={i} at {DateTime.Now}");
                //Use @ to provide a clean string literal
                Thread.Sleep(2000);
            }
            var logFilePath = @"c:\log\log.dat";
            Console.WriteLine("\n\nPrinting contents of log file\n\n");
            Console.WriteLine(File.ReadAllText(logFilePath));
        }
    }
}
