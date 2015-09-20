/*
5.  Создать  обобщенный  класс  прямой  на  плоскости.
 
В  классе предусмотреть 2 поля типа обобщенной точки – точки, через которые проходит прямая. 
 
Реализовать в классе: 
    a.  конструктор, который принимает 2 точки 
    b.  конструктор,  которые  принимает 4 координаты (x и  у координаты для 1-ой и 2-ой точки) 
    c.  метод ToString()
*/

using System;
using System.Collections.Generic;
namespace geiko.DZ_65
{
    class Program 
    {
        static void Main(string[] args)
        {
            Point<double> p1 = new Point<double>(3.0, 5.9);
            Point<double> p2 = new Point<double>(0.0, 0);
            try
            {
                Console.WriteLine(p1);
                Console.WriteLine(p2);
                if (p1.X == p2.X && p1.Y == p2.Y)
                    throw new PiontCoincidenceException("\n     The points are coincident!");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(" {0}", e.Message);
            }
            finally
            {
                Line<double> l1 = new Line<double>(p1, p2);
                Line<double> l2 = new Line<double>(0.0, 1.2, 8.7, 7.8);
                Console.WriteLine(l1);
                Console.WriteLine(l2);
            }
            Console.ReadKey();
        }
    }
}
