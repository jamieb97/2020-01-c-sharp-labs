using System;

namespace lab_20_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            for(int i =0; i < arr.Length; i++)
            {
                arr[i] = i;
                Console.Write(arr[i] + "\n");
            }

            //------------------------------------------------

            int num = 0;
            int[,] arr2d = new int[10,10];
            for(int j =0; j < arr2d.GetLength(0); j++)
            {
                for(int a =0; a < arr2d.GetLength(1); a++)
                {                 
                    arr2d[j, a] = num;
                    num++;
                    Console.Write(arr2d[j, a] + "\t");
                }

            }


            //-----------------------------------------------------
            int num2 = 0;
            int[,,] arr3d = new int[10, 10, 10];
            for (int k = 0; k < arr3d.GetLength(0); k++)
            {
                for(int x = 0; x < arr3d.GetLength(1); x++)
                {
                    for (int y = 0; y < arr3d.GetLength(2); y++)
                    {
                        arr3d[k, x, y] = num2;
                        num2++;
                        Console.Write(arr3d[k , x, y] + "\t");
                    }
                }

            }
        }
    }
}
