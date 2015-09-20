/*
5.  Разработать  приложение,  в  котором  бы  сравнивалось  население 
трёх  столиц  из  разных  стран.  Причём  страна  бы  обозначалась 
пространством имён, а город - классом в данном пространстве. 
*/

using System;

namespace DZ_35
{
    class Program
    {
        static void Main(string[] args)
        {
            Ukraine.Kiev ob1 = new Ukraine.Kiev(2850000);
            USA.NewYork ob2 = new USA.NewYork(8400000);
            Japan.Tokio ob3 = new Japan.Tokio(12800000);

            Console.WriteLine("The population of Kiev is {0} inhabitants.\n", ob1.Population);
            Console.WriteLine("The population of NewYork is {0} inhabitants.\n", ob2.Population);
            Console.WriteLine("The population of Tokio is {0} inhabitants.\n", ob3.Population);

            Console.ReadKey();
        }
    }
}