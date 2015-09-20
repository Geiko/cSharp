/*  6.  Пользователь  вводит  строку  и  символ.  В  строке  найти  все  вхождения  этого 
    символа  и  перевести  его  в  верхний  регистр,  а  также  удалить  часть  строки, 
    начиная с последнего вхождения этого символа и до конца. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_26
{
    class Program
    {
        static void Main(string[] args)
        {
            bool input = false;

            while (input == false)
            {
                Console.WriteLine("\nGive me a string.");
                string line = Console.ReadLine();
                if(String.IsNullOrEmpty(line) == true )
                {
                    Console.WriteLine("Improper input of string.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("\nGive me a character.");
                string strForChar = Console.ReadLine();
                if (strForChar.Length != 1)
                {
                    Console.WriteLine("Improper input of character.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    input = true;
                    if (line.Contains(strForChar) == false)
                    {
                        Console.WriteLine("\nThere is no the character \"" + strForChar + "\" in the string \"" + line + "\"");
                    }
                    else
                    {
                        int k=0, index, counter=0;
                        Console.Write("\nAll places (indexes) :  ");
                        for (int i = 0; i < line.Length; ++i)
                        {
                            index = line.IndexOf(strForChar, k);
                            if (index == -1)
                            {
                                break;
                            }
                            k = index + 1;
                            counter++;
                            Console.Write(index + "; ");
                        }
                        Console.WriteLine(String.Format("\n\nString \"{1}\" includs character \"{2}\" - {0} times.", counter, line, strForChar));

                        line = line.Replace(strForChar, strForChar.ToUpper());
                        Console.WriteLine("\nUpper char \"" + strForChar + "\" :  " + line);

                        int end = line.LastIndexOf(strForChar.ToUpper());
                        line = line.Remove(end);
                        Console.WriteLine("\n\nLast index = " + end + "\nTerminated string :  " + line);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
