using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace lab_54_async_await
{
    class Program
    {
        static List<string> fileRows = new List<string>();
        static void Main(string[] args)
        {
            //standard code is SYNCHRONOUS IE LINE BY LINE, THREAD IS ONLY ONE
            //THREAD AND IT 'HANGS' if you have long operators
            var s = new Stopwatch();
            s.Start();
            DoThis(); //sync
            File.Delete("log.dat");
            //async oepration
            //main thread will start the operation  but not wait for it. Main thread will  not pause
            Console.WriteLine("\n\nBuilding Text File\n\n");
            for(int i = 0; i < 10000; i++)
            {
                File.AppendAllText("log.dat", $"new log entry {i} at {DateTime.Now}\n");
            }
            Console.WriteLine("File built . . .");
            Console.WriteLine($"Starting async operations at {s.ElapsedMilliseconds}");

            ReadTextLines();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.WriteLine("Program has completed");
            Console.ReadLine();
        }

        static void DoThis()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Finished doing this");
        }

        static async void ReadTextLines()
        {
            var array = await File.ReadAllLinesAsync("log.dat");
            //fileRows.AddRange(array); //add array to list

            for(int i = 0; i <10000; i++)
            {
                if(i%1000 == 0)
                    Console.WriteLine(fileRows[i]);
            }
        }
    }
}
