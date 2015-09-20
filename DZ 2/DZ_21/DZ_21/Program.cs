/*  1.  Сжать  массив,  удалив  из  него  все 0 и  
    заполнить  освободившиеся  справа элементы значениями -1  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_21
{
    class Program
    {
        static void Main(string[] args)
        {
          //int[] arr = new int [] { 0, 1, 0, 0, 2, 0, 4, 0, 5, 0 };
            int[] arr = { 0, 1, 0, 0, 2, 0, 4, 0, 5, 0 };
            int forDelete = 0, forInsert = -1;
            foreach (int element in arr)
                Console.Write(element + "\t");
            

            for (int i = arr.Length-1; i >= 0; --i )
            {
                if (arr[i] == forDelete)
                {
                    for (int j = i; j < arr.Length - 1; ++j)
                    {
                        arr[j] = arr[j + 1];
                    }
                    arr[arr.Length - 1] = forInsert;
                }
            }


            Console.WriteLine("\n");
            foreach (int ielement in arr)
                Console.Write(ielement + "\t");
            
            Console.ReadKey();
        }
    }
}
