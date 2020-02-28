using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace lab_60_Raw_SQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                var sqlQuery = "select * from customers";

                using(var command = new SqlCommand(sqlQuery, connection))
                {
                    //read data
                    var sqlreader = command.ExecuteReader();
                    //while(sql reader has records coming in)
                    while (sqlreader.Read())
                    {
                        string customerID = sqlreader["CustomerID"].ToString();
                        string ContactName = sqlreader["ContactName"].ToString();
                        string CompanyName = sqlreader["CompanyName"].ToString();
                        string City = sqlreader["City"].ToString();

                        var customer = new Customer()
                        {
                            CustomerID = customerID,
                            ContactName = ContactName,
                            CompanyName = CompanyName,
                            City = City
                        };

                        customers.Add(customer);
                    }
                }
            }

            customers.ForEach(customer => Console.WriteLine($"{customer.CustomerID, -10}{customer.ContactName, -40}{customer.CompanyName, -40}" +
                $"{customer.City}"));
        }
    }
}
