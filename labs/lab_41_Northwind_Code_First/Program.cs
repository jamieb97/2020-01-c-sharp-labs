using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace lab_41_Northwind_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Product> products = new List<Product>();
            var customer01 = new Customer();
            customer01.CustomerID = "Cust1";
            customer01.ContactName = "Customer Fred";
            customer01.Print();

            using (var db = new NorthwindModel1())
            {
                //get customers
                //print customers
                var cust = db.Customers.ToList();

                cust.ForEach(i => i.Print());

                if (File.Exists("customer.csv"))
                {
                    File.Delete("customer.csv");
                }

                File.AppendAllText("customer.csv", "Customer,Name\n");
                products = db.Products.ToList();
                products.ForEach(product => product.Print());

                Process.Start("EXCEL", "customer.csv");
            }
        }
    }

    //can add to customer class
    partial class Customer
    {
        public void Print()
        {
            string content = $"{this.CustomerID}, {this.ContactName}\n";
            //Print customer 
            Console.WriteLine(content);
            File.AppendAllText("customer.csv", content);
        }
    }
    partial class Product
    {
        public void Print()
        {
            //Print customer 
            string content = $"{this.ProductID}, {this.ProductName}\n";
            Console.WriteLine(content);
            File.AppendAllText("customer.csv", content);
        }
    }

}
