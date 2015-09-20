/*  4.  В двумерном массиве порядка M на N поменяйте местами заданные столбцы.  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_24
{
    class Program
    {
        static void Main(string[] args)
        {
            const int m = 3, n = 5;
            int[,] arr = new int[m, n] { { 0, 1, 2, 3, 4 }, { 0, 1, 2, 3, 4 }, { 0, 1, 2, 3, 4 } };

            Print(arr);
            SwapColumns(arr, 4, 2);
            Print(arr);

            Console.ReadKey();
        }

        static void Print (int[,] ARR)
        {
            for (int i = 0; i < ARR.GetLength(0); ++i)
            {
                for (int j = 0; j < ARR.GetLength(1); ++j)
                {
                    Console.Write(ARR[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        
        static void SwapColumns(int[,] ARR, int x1, int x2)
        {
            int limit = ARR.GetLength(1)-1;
            if(x1 > limit || x2 > limit )
            {
                Console.WriteLine("Out of range! Can't swap.\n");
                return;
            }
            else
            {
                int temp;
                for (int i = 0; i < ARR.GetLength(0); ++i)
                {
                    temp = ARR[i, x1];
                    ARR[i, x1] = ARR[i, x2];
                    ARR[i, x2] = temp;
                }
            }
        }
    }
}
