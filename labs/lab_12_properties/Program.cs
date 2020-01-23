using System;

namespace lab_12_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var user01 = new User("NT353637", "AB");
            Console.WriteLine($"{user01.nINO}");
            user01.nINO = null; //reset     null means no data present in the field
        }
    }

    class User 
    {
        // private fields
        private string _NINO;
        private string _bloodType;
        private int age;

        //Constructor
        public User(string nino, string bloodtype)
        {
            this._NINO = nino;
            this._bloodType = bloodtype;
        }

        //property (public, short version)
        public int height { get; set; } // public property

        //public property
        public string nINO { get { return this._NINO; } set { this._NINO = value; } }   //value is a c# built in carrier
        public int _Age { get { return this.age; } set { this.age = value; } }                                                                                //of the data from main to instance
       
    
    }

}
