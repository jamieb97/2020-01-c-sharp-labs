using System;
using System.Diagnostics;
using System.Threading;

namespace lab_33_stopwatch_date_time
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();

            int bigNum = 1_000;
            int total = 0;
            for (int i = 0; i < bigNum; i++)
            {
                for (int j = 0; j < bigNum; j++)
                {
                    for (int k = 0; k < bigNum; k++)
                    {
                        total += 1;
                    }
                }

            }

            s.Stop();
            Console.WriteLine(s.Elapsed);               //HH:MM:SS:1234567
            Console.WriteLine(s.ElapsedMilliseconds);   //10^-3 SECONDS
            Console.WriteLine(s.ElapsedTicks);          //10^-7 SECONDS


            //dates
            var date01 = new DateTime();
            Console.WriteLine(date01);

            var date02 = DateTime.Today; //MIDNIGHT
            var date03 = DateTime.Now;   //NOW

            var date04 = new DateTime(2019, 12, 12,05,12,32); // LITERAL y m d h m s
            Console.WriteLine(date04);

            var tomorrow = date02.AddDays(1);
            var nextWeek = date02.AddDays(7);
            var timeSpan = nextWeek - date02;

            Console.WriteLine(timeSpan.ToString());

            //PRINTING THE DATE
            Console.WriteLine(tomorrow.ToShortDateString());
            Console.WriteLine(tomorrow.ToLongDateString());
            Console.WriteLine(tomorrow.ToString("dd-MM-yy HH:mm:ss"));



        }

        
    }
}
