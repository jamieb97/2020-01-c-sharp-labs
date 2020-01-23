using System;

namespace lab_21_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bigNumber = int.MaxValue;
            //Console.WriteLine(bigNumber);
            //checked { Console.WriteLine(bigNumber + 1); }

            //method1();
            void method1()
            {
                Console.WriteLine("nice");
                method1();
            }

            double x = 10;
            int y = 20;
            int a = 0;
            try {
                double z = x / y;
                double d = x / y;
                Console.WriteLine($"{x}/{y} is {z} or {d}");
                int trouble = y / a;//handled
                
            }
            catch(Exception e) 
            {
                Console.WriteLine("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
                Console.WriteLine(e);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
            }
            finally 
            {
                Console.WriteLine("yeet");
            
            }
        }


    }
}
