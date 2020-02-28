using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace lab_63_serialization
{
    class Program
    {
        //lab
        //create a list of two customers
        //convert to JSON and print JSON on the console
        //Newtonsoft.Json

        //get data
        //use httpclient to get Json as string from https://raw.githubusercontent.com/philanderson888/data/master/customers.json
        //deserialize to List<Customer> and print the list in Console
        static List<Customer> customers = new List<Customer>();

        static Uri url = new Uri ("https://raw.githubusercontent.com/philanderson888/data/master/customers.json");
        static string jsonString;
        static void Main(string[] args)
        {
            var cust1 = new Customer(1, "Jamie", "London");
            var cust2 = new Customer(2, "Jay", "444");
            customers.Add(cust1);
            customers.Add(cust2);


            var jsonout = JsonConvert.SerializeObject(customers);
            Console.WriteLine(jsonout);
            GetData();
            List<Customer> jsonList = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            jsonList.ForEach(i => Console.WriteLine($"{i.customerID} {i.CustomerName} {i.Address}"));
        }
        static void GetData()
        {
            var webClient = new WebClient { Proxy = null };
            jsonString = webClient.DownloadString(url);
            Console.WriteLine(jsonString);
        }
        
    }


    class Customer
    {
        public int customerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public Customer(int id, string customerName, string address)
        {
            customerID = id;
            CustomerName = customerName;
            Address = address;
        }
    }

}
