using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var arsenal = new Arsenal();
            var players = new Players();
            var staff = new Staff();
            var hactor = new Bellerin();

            arsenal.TeamPic();
            players.TeamPic();
            staff.TeamPic();
            hactor.TeamPic();
        }
    }


    class Arsenal
    {
        public virtual void TeamPic()
        {
            Console.WriteLine("Team photo");
        }
    }

    class Players : Arsenal 
    { 
        public override void TeamPic()
        {
            Console.WriteLine("Player photos");
        }
    
    }

    class Staff : Arsenal 
    {
        public override void TeamPic()
        {
            Console.WriteLine("Staff photos");
        }
    }

    class Bellerin : Arsenal 
    {
        public override void TeamPic()
        {
            Console.WriteLine("NA NA NA NA NA NA NA NA NA, HECTOR BELLERIN, BELLERIN, HECTOR BELLERIN");
        }
    }

}
