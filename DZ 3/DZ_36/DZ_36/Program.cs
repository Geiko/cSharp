/*
6.  Реализовать класс для хранения комплексного числа. Выполнить в 
нем перегрузку всех необходимых операторов для успешной компиляции 
следующего фрагмента кода: 
 
  Complex z = new Complex(1,1); 
  Complex z1; 
  z1 = z - (z * z * z - 1) / (3 * z * z); 
  Console.WriteLine("z1 =  {0}", z1);  
  
Любое комплексное число может быть представлено как формальная 
сумма x + iy, где x и y — вещественные числа, i — мнимая единица, то 
есть число, удовлетворяющее уравнению i2 = − 1 
*/

using System;

namespace geiko.DZ_36
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1 =  {0}", z1);

            Console.ReadKey();
        }
    }
}
