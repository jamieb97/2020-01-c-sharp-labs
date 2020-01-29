using System;

namespace lab_39_overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            var po1 = new Person();
            var po2 = new Person(10); //overloaded
            var po3 = new Person("STEEEEEVE");
            po2.DoThis(b:2,e:true, a:1, c:23, d:4, g:"hi");
        }
    }

    class Person
    {
        private int _age;
        public string name { get; set; }
        public Person() { }

        public Person(int age)
        {
            this._age = age;
        }
        public Person(string anything)
        {
            this.name = anything;
        }
        internal void DoThis(int a, int b, int c, int d, bool e, string g)
        {

        }
    }

}
