/*
Задание 2.  Разработать  абстрактный  класс  ГеометрическаяФигура 
со  свойствами ПлощадьФигуры  и  ПериметрФигуры.  
 
Разработать  классы-наследники: 
 * Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг, Эллипс 
и реализовать конструкторы, которые однозначно определяют объекты данных классов. 
  
Реализовать интерфейс 
 * ПростойНУгольник, который имеет свойства: 
Высота, Основание, УголМеждуОснованиемИСмежнойСтороной, КоличествоСторон,  ДлиныСторон, Площадь, Периметр. 
 
Реализовать  класс  СоставнаяФигура  который  может  состоять  из  любого  количества ПростыхНУгольников. 
Для данного класса определить метод нахождения площади фигуры. 
 
Предусмотреть классы исключения невозможности задания фигуры 
(введены отрицательные длины сторон; или при создании объекта треугольника существует пара сторон, 
сума длин которых меньше длины третей стороны; и т.п.) 
 
Создать диаграммы взаимоотношений классов и интерфейсов. 
  http://ru.onlinemschool.com/math/formula/area/
*/

using System;
using geiko.DZ_42.entities;

namespace geiko.DZ_42
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(0, 0);
            Point B = new Point(0, 8);
            Point C = new Point(8, 0);
            Point D = new Point(8, 8);

            try
            {
                Ellips ellips = new Ellips(A, B, C);
                Console.WriteLine(ellips);

                Circle circle = new Circle(A, C);
                Console.WriteLine(circle);

                Trapeze trapeze = new Trapeze(A, B, C, D);
                Console.WriteLine(trapeze);

                Triangle trianle = new Triangle(A, B, C);
                Console.WriteLine(trianle);

                Parallelogram parallelogram = new Parallelogram(A, B, C, D);
                Console.WriteLine(parallelogram);

                Rectangle rectangle = new Rectangle(A, B, C, D);
                Console.WriteLine(rectangle);

                Rombus rombus = new Rombus(A, B, C, D);
                Console.WriteLine(rombus);

                Square square = new Square(A, B, C, D);
                Console.WriteLine(square);   
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(" {0} ", e.Message);
            }
            finally
            {
                Console.WriteLine("\nBy !\n\n\n\n");
            }


            Console.ReadKey();
        }   
    }
}

