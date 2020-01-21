using System;
using System.Collections.Generic;
using System.Dynamic;

namespace lab_08_literal_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            //array : fixed in sixe (Immutable)
            var array01 = new int[5]; //empty memory space to hold 5 ints
            var array02 = new int[] { 10, 20, 30, 40, 50 }; //literally defining numbers

            var list01 = new List<int>();
            var list02 = new List<int>() { 1, 2, 3, 4, 5 }; //literals

            //random random
            dynamic object01 = new ExpandoObject();
            object01.name = "Fred";
            object01.age = 22;
            Console.WriteLine($"object01 has name {object01.name} and age {object01.age}");

            //or
            //creating object as literal
            var object02 = new
            {
                name = "Fred",
                age = 22
            };
            Console.WriteLine($"{object02.name} has age {object02.age}");

            //oop language : create new object using literal data
            var dog01 = new Dog() 
            { 
                name = "Milly",
                age = 10
            };
            Console.WriteLine($"{dog01.name} is {dog01.age}");

        }
    }

    class Dog 
    {
        public string name;
        public int age;
    }

}
