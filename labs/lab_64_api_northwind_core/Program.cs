using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection.Metadata.Ecma335;


namespace lab_64_api_northwind_core
{
    class Program
    {
        static Uri url = new Uri("https://localhost:44354/api/Customers");
        static List<Customer> customers = new List<Customer>();
        static Stopwatch s = new Stopwatch();
        static long SynchronousTime = 0;
        static HttpClient httpclient = new HttpClient();
        static void Main(string[] args)
        {
            Thread.Sleep(10000);
            s.Start();

            GetCustomers();

            SynchronousTime = s.ElapsedMilliseconds;
            Console.WriteLine($"\n\nFinished sync call at {s.ElapsedMilliseconds}");

            GetCustomerAsync();

            Console.WriteLine($"\n\nMain method did not for async call. Failed at {s.ElapsedMilliseconds}");

            var customer = new Customer() { CustomerID = "Jamie1", ContactName = "Test Customer", CompanyName = "McLaren", City = "London", Country = "UK"  };

            var customer2 = new Customer() { CustomerID = "Jamie2", ContactName = "Test Customer", CompanyName = "McLaren", City = "London", Country = "UK" };

            PostCustomerAsync(customer2);

            UpdateCustomerAsync(customer2);

            DeleteCustomerAsync(customer2);
            Console.ReadLine();

        }

        static void GetCustomers()
        {
            using (var client = new HttpClient())
            {
                var jsonStringTask = client.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(jsonStringTask.Result);
            }
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10} {c.CompanyName,-20} {c.ContactTitle, -30} {c.City, -20} {c.Country}"));
        }

        static async void GetCustomerAsync()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetCustomerDataAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10} {c.CompanyName,-20} {c.ContactTitle,-30} {c.City,-20} {c.Country}"));
                Console.WriteLine($"\n\nFinsihed Getting Asynchronous Data At {s.ElapsedMilliseconds}");

                Console.WriteLine($"It took {SynchronousTime} to get our data synchronously. It took {s.ElapsedMilliseconds} to get our data asynchronously.");
            }

        }

        static async Task<string> GetCustomerDataAsync()
        {
            string jsonString = null;
            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url);
            }
            return jsonString;
        }

        static HttpResponseMessage PostCustomer(Customer customer)
        {
            string customerAsJon = JsonConvert.SerializeObject(customer);
            var HttpContent = new StringContent(customerAsJon);
            HttpContent.Headers.ContentType.MediaType = "application/json";
            HttpContent.Headers.ContentType.CharSet = "UTF-8";

            var responseMessage = httpclient.PostAsync(url, HttpContent);

            return responseMessage.Result;
        }

        static async Task PostCustomerAsync(Customer customer)
        {
            var responseMessage = await PostCustomerDataAsync(customer);
            Console.WriteLine($"We have successfully added customer with HTTP Response Status Code {responseMessage.IsSuccessStatusCode}");
        }

        static async Task<HttpResponseMessage> PostCustomerDataAsync(Customer customer)
        {
            string customerAsJson = JsonConvert.SerializeObject(customer);
            var HttpContent = new StringContent(customerAsJson);
            HttpContent.Headers.ContentType.MediaType = "application/json";
            HttpContent.Headers.ContentType.CharSet = "UTF-8";

            var responseMessage = await httpclient.PostAsync(url, HttpContent);
            return responseMessage;
        }

        static async Task UpdateCustomerAsync(Customer customer)
        {
            var responseMessage = await UpdateCustomerDataAsync(customer);
            Console.WriteLine($"We have updated customer {responseMessage.IsSuccessStatusCode}");
        }

        static async Task<HttpResponseMessage> UpdateCustomerDataAsync(Customer customer)
        {
            string customerAsJson = JsonConvert.SerializeObject(customer);
            var HttpContent = new StringContent(customerAsJson);
            HttpContent.Headers.ContentType.MediaType = "application/json";
            HttpContent.Headers.ContentType.CharSet = "UTF-8";

            var responseMessage = await httpclient.PutAsync(url, HttpContent);
            return responseMessage;
        }

        static async Task DeleteCustomerAsync(Customer customer)
        {
            var responseMessage = await DeleteCustomerDataAsync(customer);
            Console.WriteLine($"We have updated customer {responseMessage.IsSuccessStatusCode}");
        }

        static async Task<HttpResponseMessage> DeleteCustomerDataAsync(Customer customer)
        {
            string customerAsJson = JsonConvert.SerializeObject(customer);
            var HttpContent = new StringContent(customerAsJson);
            HttpContent.Headers.ContentType.MediaType = "application/json";
            HttpContent.Headers.ContentType.CharSet = "UTF-8";

            var responseMessage = await httpclient.DeleteAsync(url);
            return responseMessage;
        }
    }
}
