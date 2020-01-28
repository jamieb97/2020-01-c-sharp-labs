using System;

namespace lab_36_tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis(); //action ie sends no parameters, returns nothing 
            string output = AlsoDoThis();
            string output3;
            string output2 = AndThisAlso(out output3);
            Console.WriteLine(output2);

            var output5 = FinallyThis();
            Console.WriteLine(output5.output6);
            output5.output7 += 5;
        }

        static void DoThis()
        {
            Console.WriteLine("I AM DOING IT GOSH");
        }
        static string AlsoDoThis()
        {
            return "STILL DOING IT";
        }
        static string AndThisAlso(out string output3)
        {
            output3 = "EVEN THIS REALLY?";
            return "OH GOD IT DOESNT END";
        }

        //TUPLES ARE ANONYMOUS OBJECTS
        static (string output6,int output7) FinallyThis()
        {
            return ("FINALLY WE MADE IT", 2000);
        }
    }
}
