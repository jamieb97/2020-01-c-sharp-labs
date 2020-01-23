using System;
using System.IO;
using System.Diagnostics;

namespace lab_11_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThis(100);
            DoThis("hi");
            DoThis(100000, "hello", true, DateTime.Now);
            DoThis(100000, "hello", true, DateTime.Now, 2222, 6666666); //Set optional componenets //Optional must be at end
            DoThis(x: 100, y: "hi", z: true, DateTime.Now); //named parameters
            DoThis(z: true, y: "hi", x: 100, time:DateTime.Now, optional01:2738921); //named parameters
        }

        //overloading methods : same name different parameters
        static void DoThis()
        {
            Console.WriteLine("No parameters");
        }
        static void DoThis(int x) 
        {
            Console.WriteLine($"Interger {x}");
        }
        static void DoThis(string y) 
        {
            Console.WriteLine($"String {y}");
        }


        static void DoThis(int x, string y, bool z, DateTime time)
        {
            Console.WriteLine($"{x} {y} {z} {time}");
        }

        static void DoThis(int x, string y, bool z, DateTime time, int optional01 = 100, int opt2 = 100000)
        {
            //erase file
            File.Delete("output.txt");
            File.Delete("output.cvs");

            string output = $"{x} {y} {z} {time} {optional01} {opt2}";
            Console.WriteLine($"{x} {y} {z} {time} {optional01} {opt2}\n");
            Console.WriteLine($"{x} {y} {z} {time} {optional01} {opt2}\n");
            Console.WriteLine($"{x} {y} {z} {time} {optional01} {opt2}\n");
            Console.WriteLine($"{x} {y} {z} {time} {optional01} {opt2}\n");
            Console.WriteLine($"{x} {y} {z} {time} {optional01} {opt2}\n");
            //save as text
            File.AppendAllText("output.txt", output);
            //save as csv which is comma seperated values
            string cvsoutput = $"{x} {y} {z} {time} {optional01} {opt2}\n";
            File.AppendAllText("output.cvs", cvsoutput);
            File.AppendAllText("output.cvs", cvsoutput);
            File.AppendAllText("output.cvs", cvsoutput);
            //view as spreadsheet
            Process.Start("C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE", "output.csv");
        }
    }
}
