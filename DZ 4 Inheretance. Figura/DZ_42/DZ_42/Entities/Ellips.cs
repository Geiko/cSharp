using System;

namespace geiko.DZ_42.entities
{
    class Ellips : Figure
    {
        protected Point first = new Point (0,0);    // first focus coordinate
        protected Point second = new Point(0, 1);   // second focus coordinate
        protected Point third = new Point(1,0);
        
        public Ellips (Point first, Point second, Point third)
        {
            this.first = first.DeepCopy(first);
            this.second = second.DeepCopy(second);
            this.third = third.DeepCopy(third);
            validatePoints();      
        }

        public virtual double focusInterval        
        {
            get { return distance(first, second); }
        }

        public double interval1
        {
            get { return distance(first, third); }
        }

        public double interval2
        {
            get { return distance(third, second); }
        }

        protected virtual void validatePoints()
        {

            if (focusInterval >= interval1 + interval1)
            {
                throw new 
                My_Exceptions.PointCoincidenceException("It is not an Ellips!!! There is a Point-and-Line Coincidence.\n\n");
            }
        }

        public double a             //  major semi axis
        {
            get { return (interval1 + interval2) / 2 ; }
        }

        public double b             //  minor semi axis
        {
            get { return Math.Sqrt(Math.Pow(a, 2) - Math.Pow(focusInterval / 2, 2)); }
        }


        public override double Area
        {
            get { return Math.PI * a * b; }
        }

        public override double Perimeter
        {
            get { return Math.PI * (3*(a+b) - Math.Sqrt((3*a + b)*(a + 3*b))); }     // Ramanujan formula
        }


        public override string ToString()
        {
            return string.Format(
                "\n ____________ ELLIPS ____________ \n Three points :  A{0} B{1} C{2} \n\n Focus interval = {3};\n interval1 = {4};\n interval2 = {5};\n\n Major and minor semi axis = {6}; {7};\n\n AREA = {8};\n PERIMETER = {9};"
                , first, second, third, focusInterval, interval1, interval2, a, b, Area, Perimeter );
        }
    }
}
