using System;

namespace lab_57_pass_by_reference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\nFirst run - integer is privately handled inside method\n\n");
            int x = 10;
            DoThis(x);
            Console.WriteLine($"x is {x}");
            //pass in integer but track value inside method
            //pass by reference 
            Console.WriteLine($"\n\nSecond run inside method\n");
            //move storage of x to heap : permanent tracking 
            TrackThis(ref x);
            Console.WriteLine($"IN MAIN METHOD {x}"); //1010

        }
        //private use of x ie unrelated to x passed in
        static void DoThis(int x) 
        {
            x += 10;
            Console.WriteLine($"x is {x}");
        }

        static void TrackThis(ref int x)
        {
            x += 1000;
            Console.WriteLine($"x is {x}"); //1010
        }
    }
}
