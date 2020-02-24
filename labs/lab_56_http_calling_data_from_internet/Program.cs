using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace lab_56_http_calling_data_from_internet
{
    class Program
    {
        static Uri url = new Uri("https://www.google.com");
        //static Uri url2 = new Uri("https://www.google.com");

        static void Main(string[] args)
        {
            Console.WriteLine("Program has started");
            //get web page synchronously
            //GetData();
            //GetDataAsync();
            GetDataJson();
            Console.WriteLine("Program has ended");
        }

        static void GetData()
        {
            //proxy is used as an agent middleman computer (not used here)
            var webclient = new WebClient { Proxy = null};
            webclient.DownloadFile(url,"myWebPage.html");
            //print to screen
            //Console.WriteLine(File.ReadAllText("myWebPage.html"));
        }

        static async void GetDataAsync()
        {
            var webclient = new WebClient { Proxy = null };
            //webclient.DownloadFileAsync(url, "myWebPage2.html"); //missing async keyword
            //Console.WriteLine(File.ReadAllText("myWebPage2.html"));
            var myWebPage3 = await webclient.DownloadStringTaskAsync(url); //this is proper async
            File.WriteAllText("myWebPage3.html", myWebPage3);
            Console.WriteLine(myWebPage3);
        }

        static void GetDataJson()
        {
            var url = new Uri("https://raw.githubusercontent.com/philanderson888/data/master/customers.json");
            var webclient = new WebClient { Proxy = null };
            var jsonData = webclient.DownloadString(url);
            Console.WriteLine(jsonData);
        }
        static async Task<string> GetStringAsync()
        {
            return "hi";
        }
    }
}
