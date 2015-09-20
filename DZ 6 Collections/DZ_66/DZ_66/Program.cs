/*
6.  Подсчитать,  сколько   раз  каждое  слово  встречается  в заданном  тексте. 
Результат  записать  в  коллекцию Dictionary<TKey, TValue>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_66
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = "Share prices mostly fell on Asian stock markets Monday after Greek voters rejected a European financial plan requiring new cost-cutting measures. Japan’s main measure of stock prices, the Nikkei index, lost more than two percent. However, Japan’s Chief Cabinet Secretary said events in Greece had a limited effect on stock prices in his country. ";
            string text2 = "Yoshihide Suga said “the ties between Japan and Greece economically and in the financial markets are very limited.” He also said he believed the 19 countries using the euro as money would, “take responsible actions to address the Greek situation.” Other major stock indexes in East Asia also fell. South Korea’s Kospi index fell two percent. ";
            string text3 = "Hong Kong’s Hang Seng index fell 3.2 percent -- its largest drop in more than three years. Concerns over the effects of the vote in Greece may have been partly to blame. But falling stock prices in China also concerned investors. Mainland China is Hong Kong’s biggest trading partner. On the mainland, stock price measures were mixed. The Shanghai stock exchange index rose over two percent after many days of declining prices.";
            string text4 = "The recent drop in Chinese stock prices is the sharpest in 20 years. Shares on Chinese markets have lost more than 20 percent of their value -- or $3 trillion dollars -- since June 12.";
            string text5 = "Financial experts say smaller investors are fleeing the stock market and investing in housing and other real estate.";
            string text6 = "On Saturday, a group of 21 brokerage companies said it would use $19 billion to buy shares in an effort to support stock prices. The move is supported by money borrowed from China’s central bank.";
            string text7 = "But any efforts to support prices are small in comparison to the total value of the current loses. Tony Nash is an economist working in Singapore.";
            string text8 = "“You can’t inject 120 (yuan) billion every weekend. The markets lost something like $3 trillion over the last couple of months -- that that’s a drop in the bucket compared to what would be needed to prop that market up.”";
            string text9 = "Falling stock prices also have discouraged new stock offerings. Nearly 30 Chinese companies have postponed their first stock sale to the public. The stock value decline reverses a year of strong gains for Chinese stocks, which more than doubled in value over the period.";
            string text10 = "Scott Kennedy is with the Centers for Strategic and International Studies in Washington. He said, in the past, the stock market represented only a small part of China’s economy. Now, that has changed. Still, he believes the country will reach its goal of seven percent economic growth this year.";
            string text = text1 + text2 + text3 + text4 + text5 + text6 + text7 + text8 + text9 + text10;
            Console.WriteLine(text);
            
            var counter = CountWords(text);

            var sortedByWord = counter.OrderBy(x => x.Key);
            var sortedByFrequency = sortedByWord.OrderBy(x => x.Value);

            foreach (KeyValuePair<string, int> kvp in sortedByFrequency)
                Console.WriteLine("   {0, 16} {1, 3}", kvp.Key, kvp.Value);
            

            Console.ReadKey();
        }



        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            if (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("\nThere is no word in the given text.");
                return counter;
            }

            string[] wordArray = text.Split(new Char[] { ' ', ',', '.', ':', '-', '(', ')', '“', '”', '\t', '\n' }); 
            
            foreach (string word in wordArray)
            {
                if (word.Trim() != "")
                {
                    try
                    {
                        if (counter.ContainsKey(word) == false)
                            counter.Add(word, 1);
                        else
                            counter[word]++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0}", e.Message);
                    }
                }

            }
            return counter;
        }
    }
}
