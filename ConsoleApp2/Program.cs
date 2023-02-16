using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoloeApp
{
    class Program
    {
        public static void Main()
        {
            int[,] DP = new int[7, 7];

            int[,] S = new int[7, 7];

            int[] demo = new int[7] { 30, 35, 15, 5, 10, 20, 25 };

            for (int l = 2; l <= 6; l++)
            {
                for (int i = 1; i <= 6 - l + 1; i++)
                {
                    int j = i + l - 1;

                    DP[i, j] = int.MaxValue;

                    for (int k = i; k < j; k++)
                    {
                        if (DP[i, k] + DP[k + 1, j] + demo[i - 1] * demo[k] * demo[j] < DP[i, j])
                        {
                            DP[i, j] = DP[i, k] + DP[k + 1, j] + demo[i - 1] * demo[k] * demo[j];
                            S[i, j] = k;
                        }
                    }
                }
            }

            Console.WriteLine(DP[1, 6]);

            Print(S, 1, 6);
        }

        private static void Print(int[,] s, int i, int j)
        {
            if (i == j)
                Console.Write("A" + i );
            else
            {
                Console.Write("(");

                Print(s, i, s[i, j]);
                Print(s, s[i, j] + 1, j);

                Console.Write(")");
            }
        }
    }
}