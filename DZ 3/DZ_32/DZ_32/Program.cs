/*  2. Разработать  собственный  структурный  тип  данных  для  хранения 
    целочисленных коэффициентов A и B линейного уравнения A x X + B x Y = 0.
    В  классе  реализовать  статический  метод Parse, которые  принимает 
    строку  со  значениями  коэффициентов,  разделенных  запятой  или пробелом.  
    В  случае  передачи  в  метод  строки  недопустимого  формата 
    генерируется исключение FormatException.  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_32
{
    class Program
    {
        public struct Coefficient
        {
            public int a, b;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Please, give me two coefficients of linear equation a and b. \n Format: \"int32, int32\".");
                string line = Console.ReadLine();
                Coefficient k = new Coefficient();
                try
                {
                    Parse(line, ref k.a, ref k.b);
                    Console.WriteLine(k.a + "   " + k.b);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("The catch is: \"{0}\"", e.Message);
                    continue;
                }
                finally
                {
                    Console.WriteLine("By!");
                }
            }
            Console.ReadKey();
        }

        static void Parse(string data, ref int a, ref int b)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new FormatException("No string");
            }

            data = data.Trim();
            int commaPlace = CommaCheck(data);

            string data1 = data.Substring( 0, commaPlace );                                       // Split of data to two string with comma
            string data2 = data.Substring( commaPlace + 1, data.Length - commaPlace - 1);

            a = ToNumber(data1);
            b = ToNumber(data2);
        }

        static int CommaCheck(string data)
        {
            if (data[0] == ',' || data[data.Length - 1] == ',')
                throw new FormatException("Unproper place of the comma.");
            
            int i = 0;
            int commaPlace = -1;
            int commaQuantity = 0;
            foreach (char el in data)
            {
                if (el == ',')
                {
                    commaPlace = i;
                    commaQuantity++;
                }
                i++;
            }
            if (commaQuantity > 1)
                throw new FormatException("Too many arguments.");            
            if ( commaQuantity < 1 )
                throw new FormatException("Too few arguments.");
            return commaPlace;
        }

        static int ToNumber(string line)
        {
            int x;
            bool rez = int.TryParse(line, out x);
            if(rez)
                return x;
            else
                throw new FormatException("Can't convert line to int32.");
        }
    }
}
