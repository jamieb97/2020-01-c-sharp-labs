using System;

namespace lab_17_value_reference_type
{
    class Program
    {
        static void Main(string[] args)
        {
            // copy integer : what happens
            //int x = 12;
            //int y;
            //y = x;
            //y = 23;

            //// copy array : what happens when changing values
            //int[] array01 = { 1, 2, 3, 4 };
            //int[] array02;
            //array02 = array01;
            //array01[1] = 8;

            //Console.WriteLine(x);
            //Console.WriteLine(y);
            //foreach (var item in array01)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //foreach (var item in array02)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            var doggy = new Dog();

            int num1 = 10;
            doggy.Age = 1;
            Console.WriteLine(num1);
            AddOne(num1);
            Console.WriteLine(num1); // original is unchanged
            Console.WriteLine(doggy.Age);
            AddOneYearToDogAge(doggy);
            Console.WriteLine(doggy.Age); // original altered

        }

        //pass in value type
        static void AddOne(int number)
        {
            number++;
        }
        //pass in reference (pointer)
        static void AddOneYearToDogAge(Dog d)
        {
            d.Age++;
        }
    }

    class Dog
    {
        public int Age { get; set; }
    }
}
