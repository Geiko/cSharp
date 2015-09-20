using System;

namespace geiko.DZ_42.entities
{
    class Circle : Ellips
    {
        public Circle(Point first, Point third) : base (first, first, third) { }   // first - centre of the circle, third - point on the circle

        public override double focusInterval
        {
            get { return 0; }
        }

        protected override void validatePoints()
        {

            if (focusInterval >= interval1 + interval1)
            {
                throw new My_Exceptions.PointCoincidenceException("It is not an Circle!!! There is a Point Coincidence.\n\n");
            }
        }

        public override string ToString()
        {
            return string.Format(
                "\n ____________ CIRCLE ____________ \n Two points :  A{0} B{1} \n \n Radius of the Circle = {2}; \n\n AREA = {3};\n PERIMETER = {4};"
                ,first, third, a, Area, Perimeter );
        }
    }
}
