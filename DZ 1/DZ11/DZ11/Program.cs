//  1.  Даны  целые  положительные  числа A,  B, C.  Значение  этих  чисел  программа  должна 
//  запрашивать  у  пользователя.  На прямоугольнике  размера A *  B  размещено 
//  максимально  возможное  количество  квадратов  со стороной C.  Квадраты  не 
//  накладываются  друг  на  друга.  Найти  количество  квадратов,  размещенных 
//  на прямоугольнике, а также площадь незанятой части прямоугольника. 
//  Необходимо предусмотреть служебные сообщения в случае, если в прямоугольнике 
//  нельзя  разместить  ни  одного  квадрата  со  стороной  С  (например,  если  значение  С 
//  превышает размер сторон прямоугольника). 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B, C;
            Console.Write("Enter iteger A: ");
            string line1 = Console.ReadLine();
            A = Convert.ToInt32(line1);


            Console.Write("Enter iteger B: ");
            string line2 = Console.ReadLine();
            B = int.Parse(line2);


            Console.Write("Enter iteger C: ");
            string line3 = Console.ReadLine();
            bool res = int.TryParse(line3, out C);              //  Method TryParse() is the best way to convert string to integer
            if (res == false)
            {
                Console.WriteLine("String is not a number");
                Console.ReadKey();
                return;
            }
            else
            {
                if (C > A || C > B)
                {
                    Console.WriteLine("There is no space for square.");
                }
                else
                {
                    int X = A / C * B / C;
                    Console.WriteLine("\n\nThere are {3} squares ({2}x{2}) on your rectangle ({0}x{1}).\nFree (non occupied by squares) space of the rectangle is {4}.", A, B, C, X, (A * B) - C * C * X);
                }
            }

            Console.ReadKey();
        }
    }
}
