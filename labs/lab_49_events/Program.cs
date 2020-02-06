using System;

namespace lab_49_events
{
    class Program
    {

        public delegate string MyDelegate(string x, string y);
        public static event MyDelegate MyEvent;
        static void Main(string[] args)
        {
            // add methods
            MyEvent += DoThis;
            MyEvent += DoThat;

            
            Console.WriteLine(MyEvent("jimbo", "."));
        }

        static string DoThis(string a, string b)
        {
            return "Sup " + a + "" + b;
        }
        static string DoThat(string a, string b)
        {
            return "see ya " + a + "" + b;
        }
    }
}
