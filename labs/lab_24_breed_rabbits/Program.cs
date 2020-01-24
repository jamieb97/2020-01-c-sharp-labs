using System;
using System.IO;
using System.Collections.Generic;

namespace lab_24_breed_rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            var rabbits = new List<Rabbit>(); 
            string[] names = new string[] {"hector","lionel","pierre","matteo","paul","kieran","gabbi","jadon","zlatan","kylian" };
            rabbits.Add(new Rabbit());
            rabbits[0].rabbitId = 1;
            rabbits[0].age = 0;
            rabbits[0].rabbitName = names[rand.Next(0, 9)];

            int numRabs = 0;
            int currentRab = 0;
            if(rabbits.Count < 50)
            {
                
                AgeRabbits(rabbits);
                for (int i = 0; i <= numRabs; i++)
                {
                    currentRab++;
                    rabbits.Add(new Rabbit());
                    rabbits[currentRab].rabbitId = currentRab+1;
                    rabbits[currentRab].age = 0;
                    rabbits[currentRab].rabbitName = names[rand.Next(0, 9)];
                    
                    if(i == numRabs)
                    {

                        if (rabbits.Count > 50)
                            break;
                        if (numRabs == 0)
                            numRabs = 1;
                        if (numRabs == 1)
                            numRabs = 2;
                        else
                            numRabs = rabbits.Count;
                        AgeRabbits(rabbits);
                        
                        i = 0;                      
                    }                  
                }
            } 
            rabbits.ForEach(item => Console.WriteLine($"Name: {item.rabbitName}\tAge: {item.age}\tID: {item.rabbitId}"));

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
