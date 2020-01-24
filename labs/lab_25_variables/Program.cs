using System;

namespace lab_25_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            //OVERFLOW
            //Care!!! INTEGERS WILL TAKE WRONG VALUE
            //        DECIMALS WILL TRUNCATE
            //INTEGERS
            int bigNum = int.MaxValue;
            Console.WriteLine(bigNum);
            bigNum = bigNum * 5;
            Console.WriteLine(bigNum);
            checked
            {
                //check for big numbers
            }

            //decimals - they truncate
            double num6 = 1.234567890123456789012345678901234667890123456789;
            Console.WriteLine($"long number is {num6}");

            double num7 = 0.1;
            double num8 = 0.2;
            //0.1 ie decimals are stored non-precisely in binary
            if (Math.Abs(num8 - num7) < 0.00001) 
                Console.WriteLine("numbers match");

            //string
            //string is array of chars
            string name = "Jamie";
            foreach(char c in name)
                Console.WriteLine(c);

            for(int i =0; i<name.Length; i++)
                Console.WriteLine(name[i]);


            byte byte01 = 0;   //min
            byte byte02 = 255; //max
            byte byte03 = 0b_1010_1010; //binary literal 1010 represents decimal 10 hex A
            byte byte04 = 0xAA;     //0x - What follows is HEX
        }
    }
}
