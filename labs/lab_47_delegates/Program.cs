using System;

namespace lab_47_delegates
{
    class Program
    {   
        public delegate void Delegate01();
        public delegate void Delegate02(int x, int y);
        static void Main(string[] args)
        {
            var delegate01 = new Delegate01(Method01);
            delegate01 += Method02;
            delegate01();


            var del = new Delegate02(Method03);
            del(1, 2);

            //most common delegate type is type of void MyDelegate(); ie no inputs, no outputs ==> action delegate

            var delegate03 = new Action(Method01);
            //often see word 'action()' in code == pointer to method types of void DoThis();
        }

        static void Method01()
        {
            Console.WriteLine("In method 1");
        }
        static void Method02()
        {
            Console.WriteLine("In method 2");
        }
        static void Method03(int a, int b)
        {
            Console.WriteLine($"{a} and {b}");
        }

    }
}
