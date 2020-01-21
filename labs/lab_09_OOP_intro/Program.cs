using System;

namespace lab_09_OOP_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            //var keyword INFER TYPE FROM RIGHT ie Car
            //car01 INSTANCE ie particular object created
            //Car is template used
            //() run a method when calling 'new' keyword // constructor
            var car01 = new Car();
            car01.Make = "Mclaren";
            for(int i = 0; i < 1000; i++)
            {
                //CREATE 1000 CARS
                var car = new Car();
            }
            var newCar = new Car();
            Console.WriteLine($"Initial Speed {newCar.Speed}");
            newCar.Speed++;
            newCar.Speed++;
            Console.WriteLine($"Final Speed{newCar.Speed}");
            var car02 = new Car("Mclaren", "P1", "Orange", 2200, 200);
        }
    }




    class Car
    {
        public string Make;
        public string Model;
        public string Colour;
        public int Length;
        public int Speed;

        //Constructor is present even if not stated
        //Default constructor
        public Car() 
        { 
            this.Speed = 0; // THIS keyword refers to instance object in use at the time 
        }

        public Car(string make, string model, string colour, int length, int speed) 
        {
            this.Make = make;
            this.Model = model;
            this.Colour = colour;
            this.Length = length;
            this.Speed = speed;
        }
    }
}
