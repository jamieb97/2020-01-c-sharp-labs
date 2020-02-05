using System;

namespace lab_45_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "yes";
            string y = "yes";

            var comp = new Compare();
            Console.WriteLine(comp.Comparing(x, y));
        }
    }
    #region Learning
    interface ITool01 
    {
        void MowLawn();
    }
    interface ITool02 { }
    interface IEveryoneUsesThis { void DoesThis(); }

    class Parent : IEveryoneUsesThis { public void DoesThis() { }}


    //Child inherits from one parent only but implements(uses) many tools or plugins 
    class Child : Parent, ITool01, ITool02
    {
        public void MowLawn()
        {
            Console.WriteLine("Child is now mowing lawn");
        }

        
    }
    #endregion


    interface IComparable
    {
        int Comparing(string a, string b);
    }

    class Compare: IComparable
    {
        public int Comparing(string a, string b)
        {
            //return a.CompareTo(b);
            return a.CompareTo(b);
        }
    }
}
