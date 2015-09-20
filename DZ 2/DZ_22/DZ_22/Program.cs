/*  2.  Преобразовать массив так, чтобы сначала шли все отрицательные элементы, 
    а потом положительные(0 считать положительным) */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 6, -1, 9, 0, -8, -5, 2, 0, 3 };
            PrintArr(array);

            //      Array.Sort(array);            Too easy

            int temp;
            for (int i = array.Length - 1; i >= 0; --i)
            {
                if (array[i] >= 0)
                {
                    temp = array[i];
                    for (int j = i; j < array.Length - 1; ++j)
                    {
                        array[j] = array[j + 1];
                    }
                    array[array.Length - 1] = temp;
                }
            }

            PrintArr(array);

            Console.ReadKey();
        }

        static void PrintArr( int[] arr )
        {
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
                