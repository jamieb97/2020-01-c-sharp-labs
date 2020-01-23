using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_14_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var realHoliday = new ActuallyGo();
            realHoliday.BookHotel();
            realHoliday.GetMoney();
            realHoliday.GetThere();
            realHoliday.VisitNamibia();
        }
    }

    abstract class Holiday
    {
        public abstract void GetThere();
 
        public abstract void BookHotel();

        public void VisitNamibia()
        {
            Console.WriteLine("We know where we are going");
        }
        public void GetMoney()
        {
            Console.WriteLine("Yep got the funds");
        }
    }

    class ActuallyGo : Holiday
    {
        public override void GetThere()
        {
            Console.WriteLine("Fly then drive");
        }

        public override void BookHotel()
        {
            Console.WriteLine("In Lion village");
        }
    }
}
