using System;
using System.Threading.Tasks;

namespace Balance
{
    internal class BalanseNE
    {
        public virtual void Main()
        {
            //Random rnd = new Random();
            //int y = rnd.Next(2, 11);
            //int x = y;
            //int[,] arPlayer_1 = new int[y, x];
            //int[,] arPlayer_2 = new int[y, x];

            //RandomStrategy(rnd, ref arPlayer_1);
            //RandomStrategy(rnd, ref arPlayer_2);

            //Say.Print(arPlayer_1);
            //Say.Print(arPlayer_2);

            int[,] arPlayer_1 = new int[,] {
                { 2, 6, 5 },
                { 3, 7, 4 },
                { 5, 9, 2 }
            };
            int[,] arPlayer_2 = new int[,] {
                { 4, 9, 8 },
                { 6, 8, 9 },
                { 8, 3, 5 }
            };


            long start = DateTime.Now.Ticks;
            Task.Delay(1000).GetAwaiter().GetResult();
            start = DateTime.Now.Ticks;

            GetNE(arPlayer_1, arPlayer_2);

            long timeMark1 = DateTime.Now.Ticks - start;
            Console.WriteLine("Time mark 1: " + timeMark1);

            //GetNE(arPlayer_1, arPlayer_2);
        }

        private void GetNE(int[,] arPlayer_1, int[,] arPlayer_2)
        {
            int x = arPlayer_1.GetLength(1);
            int y = arPlayer_1.GetLength(0);
            string[,] arZero = new string[y, x];
            ZeroMas(ref arZero);

            for (int i = 0; i < y; i++)
            {
                int max = arPlayer_1[0, i];
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_1[j, i] > max)
                    {
                        max = arPlayer_1[j, i];
                    }
                }
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_1[j, i] == max)
                    {
                        arZero[j, i] = Convert.ToString(max);
                    }
                }
            }

            for (int i = 0; i < y; i++)
            {
                int max = arPlayer_2[i, 0];
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_2[i, j] > max)
                    {
                        max = arPlayer_2[i, j];
                    }
                }
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_2[i, j] == max)
                    {
                        int timeItem = arPlayer_2[i, j];
                        if (int.TryParse(arZero[i, j], out arPlayer_2[i, j]))
                        {
                            arPlayer_2[i, j] = timeItem;
                            Console.WriteLine("Точка (" + arPlayer_1[i, j] + ", " + arPlayer_2[i, j] + ") с координатами ( " + (i + 1) + ", " + (j + 1) + " ) - является равновесием Нэша");
                        }
                    }
                }
            }
        }

        public void ZeroMas(ref string[,] arZero)
        {
            int x = arZero.GetLength(1);
            int y = arZero.GetLength(0);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arZero[i, j] = "-";
                }
            }
        }

        public void RandomStrategy(Random rnd, ref int[,] arPlayer)
        {
            int x = arPlayer.GetLength(1);
            int y = arPlayer.GetLength(0);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arPlayer[i, j] = rnd.Next(0, 10);
                }
            }
        }
    }
}