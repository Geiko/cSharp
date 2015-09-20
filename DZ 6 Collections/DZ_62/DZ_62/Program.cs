/*
 2.  Разработать собственный класс, имитирующий работу стека. 
*/

using System;
using System.Collections;

namespace geiko.DZ_62
{
    class MyStack<T> : ICollection
    {
        T[] container; 


        public MyStack()
        {
            container = new T[0];
        }

        public MyStack(int n)
        {
            container = new T[n];
        }


        public int Count 
        { 
            get { return container.Length; }
        }


        public bool IsSynchronized { get; set; }/////////???

        public Object SyncRoot { get; set; }/////////////???


        public IEnumerator GetEnumerator()////////////////???
        {
            for (int i = 0; i < Count; i++)
                yield return container[1];////////// yield???
        }

        IEnumerator IEnumerable.GetEnumerator()///////////???
        {
            return GetEnumerator();
        }



        public void Push(T element)
        {
            Array.Resize(ref container, container.Length + 1);
            container[Count-1] = element;
        }


        public T Pop()
        {
            if (container.Length == 0) throw new InvalidOperationException("Stack is empty!");

            T rezult = container[Count - 1];
            Array.Resize(ref container, container.Length - 1);
            return rezult;
        }


        public T Peek()
        {
            if (container.Length == 0) throw new InvalidOperationException("Stack is empty!");

            return container[Count - 1];
        }


        public bool Contains(T q)
        {
            foreach (T el in container)
                if (el.Equals(q)) 
                    return true;
            return false;
        }


        public void Clear()
        {
            container = new T[0];
        }


        public void CopyTo(Array array, int index)
        {
            container.CopyTo(array, index);
        }
        

        public  void PrintMyStack()
        {
            Console.WriteLine();
            for (int i = container.Length - 1; i >= 0; i--)
            {
                Console.WriteLine("{0}", container[i]);
            }
            Console.WriteLine();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            MyStack<char> glass = new MyStack<char>();
            Console.WriteLine("\n {0} ", glass.Count);

            glass.Push('1');
            glass.Push('2');
            glass.Push('3');
            glass.Push('4');
            glass.Push('5');

            glass.PrintMyStack();

            try
            {
                Console.WriteLine("\n Pop() = {0}", glass.Pop());
                glass.PrintMyStack();

                Console.WriteLine("\n Peek() = {0}", glass.Peek());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("\n\n{0}\n", e.Message);
            }

            Console.WriteLine("\n Contains a = {0}", glass.Contains('a'));
            Console.WriteLine("\n Contains 2 = {0}", glass.Contains('2'));

            glass.Clear();
            Console.WriteLine("\n Clear(); Length = {0}", glass.Count );

            glass.Push('1');
            glass.Push('2');
            glass.Push('3');
            glass.PrintMyStack();

            char [] aim = new char[10];
            aim.SetValue('A', 0);
            aim.SetValue('S', 1);
            aim.SetValue('F', 2);

            foreach (char el in aim)
                Console.WriteLine("{0}", el);

            glass.CopyTo(aim, 3);

            foreach (char el in aim)
                Console.WriteLine("{0}", el);
            

            Console.ReadKey();
        }
    }
}
