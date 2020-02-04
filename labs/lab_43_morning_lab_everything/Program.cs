using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_43_morning_lab_everything
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var theList = new List<int>();
            theList.Add(5);

            var theQueue = new Queue<int>();
            theQueue.Enqueue(4);

            var stackThatCheese = new Stack<int>();
            stackThatCheese.Push(3);


            Reality theNumbersMason = new Reality();
            theNumbersMason.whatDoTheyMean = 2;
            Dictionary<string, string> theDictionary = new Dictionary<string, string>();
            theDictionary.Add("txt", "here.exe");

        }


    }


    class Reality
    {
        private int somethingSomething;
        private int darkside;
        public int whatDoTheyMean { get { return this.somethingSomething; } set { this.somethingSomething = value; } }
        protected int x;
        protected int y;
        public virtual int TheGame()
        {
            return x + y;
        }
    }
    class ReadyPlayerOne : Reality
    {
        public override int TheGame()
        {
            return x + x;
        }
    }

    abstract class Yes
    {
        public abstract void WellActually();
    }
    class No : Yes 
    {
        public override void WellActually()
        {
            Console.WriteLine("Ha gottem");
        }
    }


    sealed class Walrus
    {
        public string itsNice;

    }
}
