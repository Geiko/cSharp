/*  5.  Создать метод принимающий, введенную пользователем, строку и выводящий 
    на  экран  статистику  по  этой  строке.  Статистика  должна  включать  общее 
    количество  символов,  количество  букв ( и  сколько  в  верхнем  регистре  и 
    нижнем),  количество  цифр,  количество  символов  пунктуации  и  количество 
    пробельных символов. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_25
{
    class Program
    {
        public struct Parsing
        {
            public int character, letter, upper, lower, digit, punctuation, gap;
            public void Print()
            {
                Console.WriteLine(String.Format("\n character = \t{0} \n letter = \t{1} \n upper = \t{2} \n lower = \t{3} \n digit = \t{4} \n punctuation = \t{5} \n gap = \t\t{6}", 
                    character, letter, upper, lower, digit, punctuation, gap));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Give me a string, please.");
            string line;
            line = Console.ReadLine();

            bool res = String.IsNullOrEmpty(line);
            if(res == true)
            {
                Console.WriteLine("String is empty.");
                Console.ReadKey();
                return;
            }
            else
            {
                Parsing Statistics = new Parsing();

                foreach(char elem in line)
                {
                    Statistics.character++;
                    if (Char.IsLetter(elem) == true) Statistics.letter++;
                    if (Char.IsUpper(elem) == true) Statistics.upper++;
                    if (Char.IsLower(elem) == true) Statistics.lower++;
                    if (Char.IsDigit(elem) == true) Statistics.digit++;
                    if (Char.IsPunctuation(elem) == true) Statistics.punctuation++;
                    if (Char.IsWhiteSpace(elem) == true) Statistics.gap++;
                }
                Statistics.Print();
            }

            Console.ReadKey();
        }
    }
}
