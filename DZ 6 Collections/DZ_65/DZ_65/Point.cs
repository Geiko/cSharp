using System;
using System.Collections.Generic;

namespace geiko.DZ_65
{
    class Point<T> 
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point()
        {
            X = default(T);
        }

        public Point(T x, T y)
        {
            X = x; Y = y;
        }

        public override string ToString()
        {
            return string.Format("\n Point({0}, {1});", X, Y);
        }

        public Point<T> DeepCopy(Point<T> current)
        {
            Point<T> copied = new Point<T>(current.X, current.Y);
            return copied;
        }
    }
}
