using System;
using System.Collections.Generic;

namespace lab_61_JSON_deserialize
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static string url = "https://localhost:44354/api/Customers";
        static void Main(string[] args)
        {
            //get customer from API synchronously 
            GetCustomers();
            //get customer async
        }

        static void GetCustomers()
        {

        }
    }
}
