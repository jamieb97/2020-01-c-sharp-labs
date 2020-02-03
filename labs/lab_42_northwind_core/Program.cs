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

        static void Main(string[] args)
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();

                
            }
            PrintCustomers();
            Process.Start("EXCEL", "customers.csv");
        }

        static void PrintCustomers()
        {
            if (File.Exists("customers.csv"))
            {
                File.Delete("customers.csv");
            }
            customers.ForEach(i =>
            {
                string output = $"{i.CustomerID}, {i.ContactName}, {i.CompanyName}, {i.City}, {i.Country}\n";
                Console.WriteLine(output);
                File.AppendAllText("customers.csv", output);
            });
        }

        

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
    }

    //talk to db
    class NorthwindDbContext : DbContext
    {
        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //DbSet customer
        public DbSet<Customer> Customers { get; set; }

    }

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [StringLength(5)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        [StringLength(30)]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }
    }


    class Product
    {

    }

    class Supplier
    {

    }
}
