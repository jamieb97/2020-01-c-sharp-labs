using System;

namespace lab_10_methods
{
    class Program
    {
        //MAIN METHOD starts program!!!
        static void Main(string[] args)
        {
            //call it
            DoThis();
            DontDoThis();

            void DontDoThis()
            {
                Console.WriteLine("DONT DO IT");
            }

            var Drago = new Dog();
            Drago.name = "Drago";
            Drago.age++;
            Drago.age++;
            Drago.age++;
            Drago.age++;
            Console.WriteLine($"{Drago.name} is {Drago.age} and has {Dog.numLegs} tonk legs");
        }

        //declare it
        static void DoThis()
        {
            Console.WriteLine("DO THIS");
        }
    }

    class Dog
    {
        public string name;
        public int age;
        public static int numLegs = 4;
        public Dog()
        {
            this.age = 0;
        }
        public void Grow()
        {
            this.age++;
        }
    }
}
