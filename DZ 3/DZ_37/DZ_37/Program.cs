/*
7. Разработать  класс Fraction, представляющий  простую  дробь.  В 
классе  предусмотреть  два  поля:  числитель  и  знаменатель  дроби. 
Выполнить перегрузку следующих операторов: +,-,*,/,==,!=,<,>, true и 
false.  
Арифметические действия и сравнение выполняется в соответствии с 
правилами  работы  с  дробями.  Оператор true возвращает true если 
дробь правильная (числитель меньше знаменателя),  оператор false 
возвращает true если  дробь  неправильная (числитель  больше 
знаменателя). 
Выполнить  перегрузку  операторов,  необходимых  для  успешной 
компиляции следующего фрагмента кода: 
 
Fraction f = new  Fraction(3,4); 
int a = 10; 
Fraction f1 =  f  * a; 
Fraction f2 =  a * f; 
double d = 1.5; 
Fraction f3 = f  + d; 
*/

using System;

namespace geiko.DZ_37
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            Console.WriteLine(" f = {0};\n", f); 

            int a = 10;
            Fraction f1 = f * a;
            Console.WriteLine(" f1 = {0} * {1} = {2};\n", f, a, f1);

            Fraction f2 = a * f;
            Console.WriteLine(" f2 = {1} * {0} = {2};\n", f, a, f2);

            double d = 1.5;
            Fraction f3 = f + d;
            Console.WriteLine(" f3 = {0} + {1} = {2};\n", f, d, f3);
            
            Fraction f5 = new Fraction(7, 9);
            Fraction f4 = f - f5;
            Console.WriteLine(" f2 = {0} - {1} = {2};\n", f, f5, f4);

            Fraction f6 = f / f5;
            Console.WriteLine(" f2 = {0} / {1} = {2};\n", f, f5, f6);

            Fraction f7 = new Fraction(3, 4);
            if (f == f7) Console.WriteLine(" {0} = {1};\n", f, f7);
            else Console.WriteLine(" {0} != {1};\n", f, f7);

            Fraction f8 = new Fraction(1, 9);
            if (f != f8) Console.WriteLine(" {0} != {1};\n", f, f8);
            else Console.WriteLine(" {0} == {1};\n", f, f8);

            //if (f > f8) Console.WriteLine(" {0} > {1};\n", f, f8);
            //else if (f == f8) Console.WriteLine(" {0} = {1};\n", f, f8);
            //else if (f < f8) Console.WriteLine(" {0} < {1};\n", f, f8);
        
            Console.ReadKey();
        }
    }
}
