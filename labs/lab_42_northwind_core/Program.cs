using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace lab_42_northwind_core
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Product> product = new List<Product>();
        static List<Category> category = new List<Category>();

        static void Main(string[] args)
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();

                
            }
            PrintCustomers(customers);
            //Process.Start("EXCEL", "customers.csv");


            using (var db = new NorthwindDbContext())
            {
                //LINQ basic (query) syntax
                //Would have to cast these objects to list or array to use them
                var customers01 = from customer in db.Customers select customer;

                var customer02 = 
                    from c in db.Customers 
                    where c.City=="London" || c.City == "Berlin" 
                    orderby c.ContactName descending
                    select c;
                PrintCustomers(customer02.ToList());

                var customList =
                    from c in db.Customers
                    select new
                    {
                        Name = c.ContactName,
                        City = c.City,
                        Country = c.Country
                    };
                customList.ToList().ForEach(item => Console.WriteLine($"{item.Name,-25} {item.City,-15} {item.Country}"));



                var newList =
                    from c in db.Customers
                    select new CustomObject()
                    {
                        Name = c.ContactName,
                        City = c.City,
                        Country = c.Country
                    };

                newList.ToList().ForEach(item => Console.WriteLine($"{item.Name,-25} {item.City,-15} {item.Country}"));


                //Grouping items 
                //SQL has aggregation ie sum, count, average, max and min
                //Query by city ==> count per city 
                var customersCountByCity =
                    from c in db.Customers                   
                    group c by c.City into Cities
                    orderby Cities.Count() descending
                    where Cities.Count() > 1
                    select new
                    {
                        City = Cities.Key,
                        Count = Cities.Count()
                    };
                Console.WriteLine($"\n\nLIST OF CUSTOMER COUNT BY CITY\n\n");
                foreach(var item in customersCountByCity.ToList())
                {
                    Console.WriteLine($"{item.City, -20}{item.Count}");
                }

                //Joining Tables
                //Products will have a category and link via catergory id

                var products01 =
                        (from p in db.Products
                        select p).ToList();
                //in order to add category name to output, first have to pull in categories into loacl database store (cache)
                //In linq by default we have 'lazy loading' which means query not actually run and bought into
                //memory until we actually need the data
                //var categories = db.categories; ==> lazy loading
                //                              .ToList(); ==> forcing loading 
                var categories =
                    (from c in db.Categories
                    select c).ToList();

                PrintProducts(products01.ToList());

            }
        }

        #region Print
        static void PrintCustomers(List<Customer> customersList) 
        {
            if (File.Exists("customers.csv"))
            {
                File.Delete("customers.csv");
            }
            File.AppendAllText("customer.csv", "ID,Name,Company,City,Country" + Environment.NewLine);
            customersList.ForEach(c => 
            {
                string output = $"{c.CustomerID},{c.ContactName},{c.CompanyName},{c.City},{c.Country}\n";
                Console.WriteLine(output);
                File.AppendAllText("customers.csv", output);
            });
        }
        #endregion PrintCustomer

        #region PrintProducts
        static void PrintProducts(List<Product> products)
        {
            //id,name,category id, unitprice, unitstock

            products.ForEach(p =>
            {
                string output = $"{p.ProductID},{p.ProductName},{p.CategoryID},{p.Category.CategoryName},{p.UnitPrice},{p.UnitsInStock}";
                Console.WriteLine(output);
            });
        }
        #endregion
    }


    class CustomObject 
    { 
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CustomObject(string name, string city, string country)
        {
            this.Name = name;
            this.City = city;
            this.Country = country;
        }
        public CustomObject() { }
    }


    public class Test
    {
        public int Testing()
        {
            List<Customer> customers = new List<Customer>();
            int length = 0;
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();
            }
            customers.ForEach(i => length++);
            return length;
        }

        public int Testing_2()
        {
            var customers = new List<Customer>();
            int length = 0;
            //add new customer here
            customers.Add(new Customer());
            customers[customers.Count].CustomerID = "DBUIA";
            customers[customers.Count].ContactName = "Jamie";
            customers[customers.Count].CompanyName = "McLaren";

            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();
            }
            customers.ForEach(i => length++);
            return length;
        }
        public int Testing_3()
        {
            var customers = new List<Customer>();
            int length = 0;
            //add new customer here
            customers.RemoveAt(customers.Count -1);

            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();
            }
            customers.ForEach(i => length++);
            return length;
        }
    }
}
