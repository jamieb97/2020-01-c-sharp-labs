using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_16_access_modifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent();
            var c = new Child();
            var t = new GrandChild();
            var b = new a.yes();

            var d = new Dog();
            d.name = "Rocky";
            p.TakeForWalk(d);
        }
    }

    class Dog 
    { 
        public string name { get; set; }
        
    
    }

    class Parent
    {
        private int hidden;
        public string exposed { get; set; }

        internal bool isUserLive;       //visible inside .exe/dll but not outside it

        protected string familyName;    //visible inside the child

        public void TakeForWalk(Dog d)
        {
            Console.WriteLine($"taking {d.name} for a walk");
        }
    }

    class Child : Parent
    {
        //cant out code directly into class

        //use constructor but could use any method

        public Child()
        {
            this.familyName = "Martinelli";
        }
    
    }

    class GrandChild : Child
    {
        
    }

}

namespace a 
{
    class yes { }
}
