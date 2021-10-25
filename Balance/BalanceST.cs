using System;

namespace Balance
{
    class BalanceST : BalanseNE
    {
        public override void Main()
        {
            //Random rnd = new Random();
            //int y = rnd.Next(2, 11);
            //int x = y;
            //int[,] arPlayer_1 = new int[y, x];
            //int[,] arPlayer_2 = new int[y, x];

            //RandomStrategy(rnd, ref arPlayer_1);
            //RandomStrategy(rnd, ref arPlayer_2);

            int[,] arPlayer_1 = new int[,] {
                { 2, 0, 1 },
                { 2, 3, 0 },
                { 0, 1, 3 }
            };
            int[,] arPlayer_2 = new int[,] {
                { 1, 3, 1 },
                { 3, 1, 2 },
                { 1, 1, 3 }
            };

            Say.Print(arPlayer_1);
            Say.Print(arPlayer_2);

            GetST1(arPlayer_1, arPlayer_2);
        }

        private void GetST1(int[,] arPlayer_1, int[,] arPlayer_2)
        {
            int x = arPlayer_1.GetLength(1);
            int y = arPlayer_1.GetLength(0);
            string[,] arZero = new string[y, x];
            ZeroMas(ref arZero);

            for (int i = 0; i < y; i++)
            {
                int maxPlayer_1 = arPlayer_2[i, 0];
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_2[i, j] > maxPlayer_1)
                    {
                        maxPlayer_1 = arPlayer_2[i, j];
                    }
                }
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_2[i, j] == maxPlayer_1)
                    {
                        arZero[i, j] = Convert.ToString(arPlayer_1[i, j]);
                    }
                }
            }
            Say.Print(arZero);

            int timeInt = 0;
            int? maxPlayer_2 = null;
            int num;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    string maxTime = arZero[i, j];
                    bool numberInt = int.TryParse(maxTime, out timeInt);
                    if(numberInt == true)
                    {
                        num = Convert.ToInt32(arZero[i, j]);

                        if(maxPlayer_2 != null)
                        {
                            if(num >= maxPlayer_2)
                            {
                                maxPlayer_2 = num;
                            }
                        }
                        else
                        {
                            maxPlayer_2 = num;
                        }
                        numberInt = false;
                    }
                }
            }
            string maxCoord_2 = Convert.ToString(maxPlayer_2);
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if(arZero[i, j] == maxCoord_2)
                    {
                        Console.WriteLine("Точка (" + arPlayer_1[i, j] + ", " + arPlayer_2[i, j] + ") с координатами ( " + (i + 1) + ", " + (j + 1) + " ) - является равновесием Штакельберга для первого игрока");
                    }
                }
            }
        }

        private void GetST2(int[,] arPlayer_1, int[,] arPlayer_2)
        {
            int x = arPlayer_1.GetLength(1);
            int y = arPlayer_1.GetLength(0);
            string[,] arZero = new string[y, x];
            ZeroMas(ref arZero);

            for (int i = 0; i < y; i++)
            {
                int maxPlayer_1 = arPlayer_1[0, i];
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_1[i, j] > maxPlayer_1)
                    {
                        maxPlayer_1 = arPlayer_1[i, j];
                    }
                }
                for (int j = 0; j < x; j++)
                {
                    if (arPlayer_1[i, j] == maxPlayer_1)
                    {
                        arZero[i, j] = Convert.ToString(arPlayer_2[i, j]);
                    }
                }
            }
            Say.Print(arZero);

            // точка остановки

            int timeInt = 0;
            int? maxPlayer_2 = null;
            int num;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    string maxTime = arZero[i, j];
                    bool numberInt = int.TryParse(maxTime, out timeInt);
                    if (numberInt == true)
                    {
                        num = Convert.ToInt32(arZero[i, j]);

                        if (maxPlayer_2 != null)
                        {
                            if (num >= maxPlayer_2)
                            {
                                maxPlayer_2 = num;
                            }
                        }
                        else
                        {
                            maxPlayer_2 = num;
                        }
                        numberInt = false;
                    }
                }
            }
            string maxCoord_2 = Convert.ToString(maxPlayer_2);
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (arZero[i, j] == maxCoord_2)
                    {
                        Console.WriteLine("Точка (" + arPlayer_1[i, j] + ", " + arPlayer_2[i, j] + ") с координатами ( " + (i + 1) + ", " + (j + 1) + " ) - является равновесием Штакельберга для первого игрока");
                    }
                }
            }
        }
    }
}
