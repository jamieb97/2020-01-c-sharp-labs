using System;
using System.Collections;

namespace lab_44_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unary
            //Increment operator ++ --
            //Be very wary of this operator
            //Safe rule always use it on standalone line

            int x = 10;

            //read as y = x first ie y =10 then increment x to 11
            int y = x++;

            Console.WriteLine(x);
            Console.WriteLine(y);


            //z = increment y first from 10 to 11
            int z = ++y;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);



            //Binary Operators
            //BODMAS 

            //Modulus = remainder
            //can easily seperate fractional parts 

            //ternary operator
            if (1 == 1) { }
            else { }

            //replace with
            var output = (1==1) ? "output this if true" : "output this if false";

            
        }
    }


    //class Test : IEnumerable 
    //{ 
    //    //must implement get enumerator
        
    //}

}
