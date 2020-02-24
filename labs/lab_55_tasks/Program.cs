using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace lab_55_tasks
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            //main thread

            //create a background task
            //note: a new task spawns a new thread on our computer and the cpu manages it, no longer under programmer control
            //argument is delegate type
            //lambda ==> create anonymous delegate type
            //                          () input parameters
            //                                  { } code body
            //                              => method with no name
            var task01 = new Task(() => {
                Console.WriteLine($"Task 01 in progress {s.ElapsedMilliseconds}");
                for (int i = 0; i <= 100; i++)
                {
                    Console.WriteLine($"Running {i} at {s.ElapsedMilliseconds}");
                }
            });
           // var s = new Stopwatch();
            s.Start();
            Console.WriteLine($"Calling task01 at time {s.ElapsedMilliseconds}");

            task01.Start();

            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"\t\t\tRunning {i} at {s.ElapsedMilliseconds}");
            }

            //task.run
            var task02 = Task.Run(() => { Console.WriteLine($"\t\t\t\t\t task 02 is running {s.ElapsedMilliseconds}"); });
            var task03 = Task.Run(() => { Console.WriteLine($"\t\t\t\t\t task 03 is running {s.ElapsedMilliseconds}"); });
            var task04 = Task.Run(() => { Console.WriteLine($"\t\t\t\t\t task 04 is running {s.ElapsedMilliseconds}"); });

            //older variants
            var task05 = Task.Factory.StartNew(() => { Console.WriteLine("Running in a task factory"); });

            //array of task: good for background batch jobs at night 
            //array of tasks
            var taskArray01 = new Task[3];
            //individual tasks in this array
            taskArray01[0] = Task.Run(() => {
                Thread.Sleep(1500);
                Console.WriteLine($"\t\t\t\t\t\tFirst task in array {s.ElapsedMilliseconds}");
            });
            taskArray01[1] = Task.Run(() => {
                Thread.Sleep(1500);
                Console.WriteLine($"\t\t\t\t\t\tSecond task in array {s.ElapsedMilliseconds}"); 
            });
            taskArray01[2] = Task.Run(() => {
                Thread.Sleep(1500);
                Console.WriteLine($"\t\t\t\t\t\tThird task in array {s.ElapsedMilliseconds}"); 
            });


            //waiting for tasks
            //can wait for at least one array task to complete
            Task.WaitAny(taskArray01);

            //or all
            Task.WaitAll(taskArray01);


            Console.WriteLine($"Program end at {s.ElapsedMilliseconds}");
            Console.ReadLine();

            s.Restart();
            var task06 = Task<string>.Run(() => { return "Task06 returns a string "; });
            Console.WriteLine(task06.Result);

            Console.WriteLine($"Program Finally ends at {s.ElapsedMilliseconds}");

            for(int i = 0; i < 1000; i++)
            {
                //database read or file read
                //could have named method or lambda : anonymous method
            }
            //running multiple named methods in parellel
            //image 20 nightly backup/cleanup jobs every night
            //useful if order of execution does not matter : run ion parallel ie togetehr
            Parallel.Invoke(() =>
            {
                NightRunTask01();
                NightRunTask02();
                NightRunTask03();
                NightRunTask04();
            });
            Parallel.For(0, 100, i => { Console.WriteLine($"Running task {i} in a loop"); });

            var myArray = new string[] { "first", "second", "third" };
            Parallel.ForEach(myArray, (item) => { Console.WriteLine($"Printing item {item}"); });


            //ENTITY LINQ DATABASE READS IN PARALLEL TO GET LOTS OF INFO AT SAME TIME
            //PREVIOUSLY WE RAN ENTITY IN SERIAL
            var customersFromDatabase = new List<Customer>();
            var customers = customersFromDatabase.AsParallel(); //execute query in parallel


            Console.ReadLine();
        }

        static void NightRunTask01() { Console.WriteLine("Running night time maintenance 01"); }
        static void NightRunTask02() { Console.WriteLine("Running night time maintenance 02"); }
        static void NightRunTask03() { Console.WriteLine("Running night time maintenance 03"); }
        static void NightRunTask04() { Console.WriteLine("Running night time maintenance 04"); }

        class Customer { }
    }
}
