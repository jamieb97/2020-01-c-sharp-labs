using System;
using System.IO;
using System.Text;
using System.Text.Unicode;

namespace lab_62_streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("data.txt");
            //create file (append, UTF8, Buffer 1024)

            using (var writer = new StreamWriter("data.txt",true, Encoding.UTF8,1024))
            {
                for(int i =0 ; i < 10; i++)
                {
                    writer.WriteLine($"New log item {i}: {DateTime.Now}");
                }
            }
            //also could use for string or array of strings
            string oneExtraLine = "some more text";
            using (var writer = File.AppendText("data.txt"))
            {
                writer.WriteLine(oneExtraLine);
            }
            //read file
            string output = null;
            using (var reader = new StreamReader("data.txt"))
            {
                //3 ways to read data
                //1
                while ((output = reader.ReadLine()) != null)
                {
                    Console.WriteLine(output);
                }
            }


            ReadDataAsync(); //off the main

            ReadAndWriteToMemory();


            Console.WriteLine("program ended");
        }
        static async void ReadDataAsync()
        {
            string output = null;
            using (var reader = new StreamReader("data.txt"))
            {
                while((output = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(output + "hi");
                }
            }
        }
        static void ReadAndWriteToMemory()
        {
            //wrapper around a memory stream : use in security
            //destination is assumed in ram : system will handle destination
            using (var memoryStream = new MemoryStream())
            {
                //memory only operates with byte stream of raw binary 1/0 
                //does not use character stream
                var buffer = new byte[4]; //byte array (empty)
                                          //fill with binary data
                buffer[0] = (int)'h';
                buffer[1] = (int)'e';
                buffer[2] = (int)'h';
                buffer[3] = (int)'e';
                //send fake data 10 times
                for (int i = 0; i < 10; i++)
                {                   
                    memoryStream.Write(buffer);
                }
                //force buffer to be sent
                memoryStream.Flush();

                //read back data with memory reader
                //but first rest pointer of stream to start
                memoryStream.Position = 0;
                using (var reader = new StreamReader(memoryStream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
