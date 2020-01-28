using System;

namespace lab_35_variables_final
{
    class Program
    {
        // readonly in class field
        readonly public static double PII = 3.1415;
        //property - use get but not set // set with constructor but not at no other type
        public DateTime DateOfBirth { get; }
        static void Main(string[] args)
        {
            // const
            const double PI = 3.1415;

            var p = new Parent();
            //p.DateOfBirth = DateTime.Now;
            Console.WriteLine(p.DateOfBirth);


            var emptyString = "";       // box for data but nothing in the box
            string nullString = null;   // points to null element
            Console.WriteLine($"Is an empty string null? {emptyString == nullString}");

            //null coalesce
            //IF ... is null ... do this ... else ... do this
            string databaseItem = null;
            string myItem = databaseItem ?? "invalid value";
            Console.WriteLine(myItem);

            databaseItem = "real item";
            myItem = databaseItem ?? "invalid item";
            Console.WriteLine(myItem);

            databaseItem = null;
            //cant take length og null so will throw exception
            //Console.WriteLine(databaseItem.Length);
            //null check
            Console.WriteLine(databaseItem?.Length); // safely returns null

            //casting and boxing
            //casting is from one type to another
            // EXPLICIT
            double num01 = 1.23;
            int interger01 = (int)num01; // cast is a dangerous operation ==> cut / truncate data
            Console.WriteLine($"{num01} becomes {interger01}");
            //safe casting. ok from int to double 1 ==> 1.0 safely
            // IMPLICIT
            int interger02 = 12;
            double num02 = interger02;

            //boxing just casts to a general object
            var item01 = 12;
            var item02 = "hi";
            var object01 = (object)item01;
            var object02 = (object)item02;
            //object is parent of all parents ie. top of computer hierarchy
            var getMyItemBack = (int)object01;

        }
    }

    class Parent
    {

        public DateTime DateOfBirth { get; }
        public Parent()
        {
            this.DateOfBirth = DateTime.Today;
        }

    }
}
