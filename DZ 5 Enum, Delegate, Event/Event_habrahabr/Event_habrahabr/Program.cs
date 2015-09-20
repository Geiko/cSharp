using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_habrahabr
{
    class ClassCounter
    {
        public delegate void MethodContaner();

        public event MethodContaner onCount;


        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 71)
                {
                    onCount();
                }
            }
        }
    }

    class Handler_I
    {
        public void Message()
        {
            Console.WriteLine("Time to act. It is 71 already."); 
        }
    }

    class Handler_II
    {
        public void Message()
        {
            Console.WriteLine("Exactly. 71. ");
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            ClassCounter counter = new ClassCounter();
            Handler_I handler1 = new Handler_I();
            Handler_II handler2 = new Handler_II();

            counter.onCount += handler1.Message;
            counter.onCount += handler2.Message;

            counter.Count();


            Console.ReadKey();
        }
    }
}
