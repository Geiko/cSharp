/*
3.  Создать  примитивный  англо-русский  и  русско-английский 
словарь, содержащий пары слов – названий стран на русском 
и  английском  языках.  Пользователь  должен  иметь 
возможность выбирать направление перевода и запрашивать перевод. 
*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace DZ_63
{
    class CountryDictionary
    {
        public Dictionary<string, string> English_Russian;
        
        public CountryDictionary()
        {
            English_Russian = new Dictionary<string,string>();
        }


        public bool Translate(string country, bool direction)
        {
            if (direction == false)
            {
                if (English_Russian.ContainsKey(country) == false)
                {
                    Console.WriteLine("Key is not found.");
                    return false;
                }
                Console.WriteLine("\n{0,16} - {1}", country, English_Russian[country]);
            }
            else
            {
                if (English_Russian.ContainsValue(country) == false)
                {
                    Console.WriteLine("Value is not found.");
                    return false;
                }
                Console.WriteLine("\n{0,16} - {1}", country, English_Russian.FirstOrDefault(x => x.Value == country).Key);           
            }
            return true;
        }


        public void PrintDictionary(Dictionary<string, string> glossary)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in glossary)
            {
                Console.WriteLine("{0, 16} - {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CountryDictionary book = new CountryDictionary();

            try
            {
                book.English_Russian.Add("Ukraine", "Украина");
                book.English_Russian.Add("France", "Франция");
                book.English_Russian.Add("USA", "США");
                book.English_Russian.Add("China", "Китай");
                book.English_Russian.Add("Japan", "Япония");
                book.English_Russian.Add("China", "Китай");
                book.English_Russian.Add("China", "Китай");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\n\nArgument is exists already.", e.Message);
            }
            finally
            {
                Dictionary<string, string> Russian_to_English = book.English_Russian.ToDictionary(x => x.Value, x => x.Key);
                book.PrintDictionary(book.English_Russian);
                book.PrintDictionary(Russian_to_English);
            }

            Console.WriteLine("\nWhich direction whould you like to translate?");
            Console.WriteLine(" (0) English -> Russian     or     (1) Russian -> English.");
            Console.WriteLine("Give me \"0\" or \"1\":");
            string dir = Console.ReadLine();
            if (dir == "0")
                dir = "false";
            else if (dir == "1")
                dir = "true";

            bool direction;
            bool res = bool.TryParse(dir, out direction);
            if (res == true)
            {
                do
                {
                    if (direction == false)
                        Console.WriteLine("Ok. Give me country name in English.");
                    else
                        Console.WriteLine("Ok. Give me country name in Russian.");

                    string country = Console.ReadLine();

                    book.Translate(country, direction);

                    Console.WriteLine("\nContinue? 0-no, any key - yes.");
                    string cont = Console.ReadLine();
                    if (cont == "0")
                        break;
                } while (true);
            }
            else
            {
                Console.WriteLine("Direction is not correct.");
            }

            Console.ReadKey();
        }
    }
}
