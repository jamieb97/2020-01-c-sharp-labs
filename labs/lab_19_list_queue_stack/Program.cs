using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; //query language LANGUAGE INDEPENDENT QUERY
                   //can now use =>

namespace lab_19_list_queue_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() {1,2,3,4,5 };
            list.Add(50);
            list.Add(22); //at end
            list.Insert(0, 5); //add 5 at index 0

            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            //foreach item in 'list' do this...
            list.ForEach(item => Console.WriteLine(item));


            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            foreach(int i in queue)
            {
                Console.WriteLine(i);
            }
            queue.Dequeue();
            queue.Dequeue();
            
            foreach (int i in queue)
            {
                Console.WriteLine(i);
            }


            
            var rand = new Random();
            
            var stack = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(rand.Next(1, 100));               
            }
            foreach (var item in stack)
            {
                Console.Write(item + ", ");
            }
            stack.Pop();
            stack.Pop();
            stack.Pop();
            foreach (var item in stack)
            {
                Console.Write(item + ", ");
            }

            //Dictionary
            //Dictionary uses ORDERED SETS ie key is UNIQUE AND ORDERED, value is the data

            var dict = new Dictionary<int, string>();
            dict.Add(1, "hi");
            dict.Add(2, "there");
            dict.Add(3, "people");
            // error dict.Add(3,"anything");
            foreach(var item in dict)
            {
                Console.WriteLine($"Key {item.Key} has value {item.Value}");
            }

            //List of Objects
            //Sometimes we have to deal with collections of generic objects
            var arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add("hello");
            arrayList.Add(new object());

            foreach(var item in arrayList)
            {
                Console.WriteLine($"Item {item} has type { item.GetType()}");
            }
            Console.WriteLine((int)arrayList[0]+59);
            Console.WriteLine((string)arrayList[1]+59);
        }
    }
}
