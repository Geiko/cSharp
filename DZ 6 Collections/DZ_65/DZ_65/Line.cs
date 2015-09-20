using System;
using System.Collections.Generic;

namespace geiko.DZ_65
{
    class Line<T> 
    {
        Point<T> p1;
        Point<T> p2;

        public Line(Point<T> p1, Point<T> p2)
        {
            this.p1 = p1.DeepCopy(p1);
            this.p2 = p2.DeepCopy(p2);
        }

        public Line(T x1, T y1, T x2, T y2)
        {
            this.p1 = new Point<T>(x1, y1);
            this.p2 = new Point<T>(x2, y2);
        }

        public override string ToString()
        {
            return string.Format("\n  (x - {0}) / ({2} - {0}) = (y - {1}) / ({3} - {1});\n", p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}
