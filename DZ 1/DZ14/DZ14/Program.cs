//  4.  Дано  целое  число N  (> 0),  найти  число,  полученное  при прочтении  числа N  справа налево. 
//  Например,  если  было  введено  число  345,  то  программа  должна  вывести число 543. 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ14
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 12345;

            string line2 = string.Empty;
            string line3 = string.Empty;
            string line4 = string.Empty;
            string line5 = string.Empty;

            string line1 = n.ToString();
            string temp;
            int len = line1.Length;
            for ( int i = 0; i < len; ++i )
            {
                temp = line1.Substring(len - 1 - i, 1);

                line2 = line2 + temp;
                line3 = string.Concat(line3, temp);
                line4 = string.Format("{0}{1}", line4, temp);
                line5 = new StringBuilder(line5).Append(temp).ToString();
            }

            Console.Write("\n\n\nn = " + line1 + "   -   " + line2 + " " + line3 + " " + line4 + " " + line5);

            int N = int.Parse(line5);

            Console.WriteLine("\n\n\nN = " + N);
            Console.ReadKey();
        }        
    }
}
