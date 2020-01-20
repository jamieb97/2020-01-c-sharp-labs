using System;
using lab_03_library_files;

namespace lab_03_use_library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program is going to call and use a library");


            //OOP : New instance to talk to Class
            var myInstance = new MyClass();

            Console.WriteLine(myInstance.DoubleUp(10));
            Console.WriteLine(myInstance.GravitationalConstant);

            Console.WriteLine("Now reference static items");
            Console.WriteLine(MyClass.AlsoTripleUp(10));
            Console.WriteLine(MyClass.NaturalLogaruthm);
        }
    }
}
