/*  3.  Написать программу, которая предлагает пользователю ввести число и 
    считает сколько раз это число встречается в массиве. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_23
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,     1, 3, 5, 7, 9 };
            bool result = false;

            while (result == false)
            {
                Console.Write("Give me integer, please: ");
                string valueStr = Console.ReadLine();
                int value;
                result = int.TryParse(valueStr, out value);
                if (result == false)
                {
                    Console.WriteLine("\nERROR! It is not integer.");
                }
                else
                {
                    int counter = 0;
                    Console.WriteLine();
                    foreach(int elem in arr)
                    {
                        if (elem == value)
                            counter++;
                        Console.Write(elem + " ");
                    }
                    Console.WriteLine(String.Format("\n\nValue ({0}) has encountered {1} times in the array.", value, counter));
                }
            }
            Console.ReadKey();
        }
    }
}
