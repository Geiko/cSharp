/*
Разработать  абстрактный  класс  ГеометрическаяФигура со  свойствами ПлощадьФигуры  и  ПериметрФигуры.
*/

using System;

namespace geiko.DZ_42.entities
{
    public abstract class Figure: ui.I_Figura
    {
        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        public double distance(Point A, Point B)
        {
            return Math.Pow((Math.Pow(Math.Abs((double)B.X - A.X), 2.0) + Math.Pow(Math.Abs((double)B.Y - A.Y), 2.0)), 0.5);
        }

        public abstract override string ToString();
    }
}
