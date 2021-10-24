using System;
using System.Collections.Generic;
using System.Text;

namespace Balance
{
    internal class Say
    {
        public static void Print(object[,] mas)
        {
            int x = mas.GetLength(1);
            int y = mas.GetLength(0);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Environment.Exit(0);
        }

        public static void Print(int[,] mas)
        {
            int x = mas.GetLength(1);
            int y = mas.GetLength(0);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Environment.Exit(0);
        }
    }
}
