using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_27_database_test
{
    class Program
    {
        static void Main(string[] args)
        {

            //2 things
            //1 wrap database call in 'using' statement
            //       using ==> clean up code afterwards even if system failure
            //2 new instance of database

            //empty list to put data in
            List<testtable> itemList = new List<testtable>();

            using (var db = new testdatabaseEntities())
            {
                //list of items = (call the database), extract test data, convert output to a list type
                itemList = db.testtables.ToList();

            }
            //foreach ... print items
            foreach (var item in itemList)
            {
                Console.WriteLine($"Name : {item.TestName,-15} Id: {item.TestTableID - 10} Age: {item.TestAge - 5}");               
            }
        }
    }
}
