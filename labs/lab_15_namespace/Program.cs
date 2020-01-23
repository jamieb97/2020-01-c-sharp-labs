    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_15_namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var instanceA = new A.X();
            var instanceB = new B.X();
        }
    }
}

namespace A
{

    class X
    {
        public static string Message = "X in A";
    }
}

namespace B
{

    class X 
    { 
        public static string Message = "X in B";

    }
}
