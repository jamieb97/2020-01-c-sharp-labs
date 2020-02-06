using System;

namespace lab_48_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child("Fred");
            c.Grow();
            c.Grow();
            c.Grow();
            Console.WriteLine(c.Age);
        }
    }

    class Child 
    {
        //declare delegate and event here
        delegate void BirthdayDelegate();
        event BirthdayDelegate BirthdayEvent;

        private string _name;
        //properties
        public string Name { get { return this._name; } set { this._name = value; } }
        public int Age { get; set; }
         
        public Child(string name)
        {
            this._name = name;
            this.Age = 0;
            //initialise event by adding at least one method
            BirthdayEvent += HaveABirthdayParty;
        }
        public void Grow()
        {
            //trigger event
            BirthdayEvent();
        }

        void HaveABirthdayParty()
        {
            Console.WriteLine("child is having a party");
            Age++;
        }
    }

}
