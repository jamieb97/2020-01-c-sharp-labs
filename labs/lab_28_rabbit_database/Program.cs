using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_28_rabbit_database
{
    class Program
    {
        static void Main(string[] args)
        {
            List<rabbittable> rabbits = new List<rabbittable>();

            var newrabbit = new rabbittable()
            {
                RabbitName = "Jimbob",
                RabbitAge = 2
            };

            using (var db = new rabbitdatabaseEntities())
            {
                
                db.rabbittables.Add(newrabbit);
                db.SaveChanges();
                rabbits = db.rabbittables.ToList();

            }

            

            foreach (var item in rabbits)
            {
                Console.WriteLine($"Name: {item.RabbitName, -15} Age: {item.RabbitAge, -10} ID: {item.RabbitTableID, -5}");
            }
        }
    }
}
