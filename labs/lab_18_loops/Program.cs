using System;

namespace lab_18_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            //for(int i = 0; i < 10; i++)
            //{

            //}
            //string yes = "sd";
            //foreach(char c in yes)
            //{

            //}
            //int x = 0;
            //bool hj = true;
            //while(hj)
            //{
            //    x++;
            //    Console.WriteLine(x);
            //    if (x > 5)
            //        hj = false;
            //}

            //int y = 10;
            //do
            //{
            //    y--;
            //} while (y > 0);

            //for(int i = 1; i < 100; i++)
            //{
            //    if (i % 5 != 0) continue;
            //        Console.WriteLine(i);
            //    if (i == 90) break;
            //}

            int a = 10;

            /* do loop execution */
            do
            {
                if (a == 15)
                {
                    /* skip the iteration */
                    a = a + 1;
                    continue;
                }
                Console.WriteLine("value of a: {0}", a);
                a++;
            }
            while (a < 20);
            Console.ReadLine();


            //RETURN
            //If we are in a methid then we can exit the loop and exit the method at the same time 
            //using the RETURN keyword

            DoThis();
            void DoThis()
            {
                for(int k = 1; k < 100; k++)
                {
                    if (k == 10) return;
                    Console.WriteLine($"In method DoThis - i is {k}");
                }
                
            }


            //THROW
            //In some bigger applications they want to track when errors occur eg from validation

            for(int num2 = 0; num2 < 10; num2++)
            {
                if (num2 == 5)
                    throw new Exception("Invalid number");
            }
        }
    }
}
