using System;
using System.IO;
using System.Collections.Generic;

namespace lab_23_rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            string[] names = new string[] {"hector","lionel","pierre","matteo","paul","kieran","gabbi","jadon","zlatan","kylian" };
            var rabbit = new List<Rabbit>();

            for(int i =0; i < 100; i++)
            {
                rabbit.Add(new Rabbit());
                rabbit[i].rabbitId = i;
                rabbit[i].age = rand.Next(0,5);
                rabbit[i].rabbitName = names[rand.Next(0, 9)];
            } 

            rabbit.ForEach(item => Console.WriteLine($"Name: {item.rabbitName}\tAge: {item.age}\tID: {item.rabbitId}"));
            //lab 1

            //create 100 rabbits
            //give them all ID, name and age
            //print a sample (every 10 items)

            //lab 2
            //create a loop to 'age' the rabbits
            //Iterate 50 times and update all the ages
            //print a sample

            AgeRabbits(rabbit);
            rabbit.ForEach(item => Console.WriteLine($"Name: {item.rabbitName}\tAge: {item.age}\tID: {item.rabbitId}"));
            //bonus : put this into WPF
            void AgeRabbits(List<Rabbit> rabage)
            {
                rabage.ForEach(item => item.age++);
            }
        }
    }
    class Rabbit 
    { 
        public int rabbitId { get; set; }
        public string rabbitName { get; set; }
        public int age { get; set; }
    
    }

}
