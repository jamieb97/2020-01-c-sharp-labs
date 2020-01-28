using System;

namespace lab_34_enum
{
    class Program
    {
        static void Main(string[] args)
        {
            //ENUM GOOD FOR ITEMS NOT CHANGING
            //DAYS OF THE WEEK
            //MONTHS OF THE YEAR
            var fruit01 = Fruit.Apple;
            Console.WriteLine(fruit01);
            Console.WriteLine((int)fruit01);
            Console.WriteLine($"hOw MaNy FrUiTs??? {(int)Fruit.Count}");

            //enums can be used sometimes in POWERS OF 2 TO GENERATE CODES
            // READ = 1 WRITE = 2 EXECUTE(RUN) = 4
        }
    }

    enum Fruit
    {
        Apple, Pear, Lemon, Strawberry, Count
    }

    enum Vegetables
    {
        onion=10, leek, potato, turnip
    }

    enum Permissions
    {
        read =1, write =2, execute=4
    }
}
