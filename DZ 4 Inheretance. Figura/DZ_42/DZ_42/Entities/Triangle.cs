using System;

namespace geiko.DZ_42.entities
{
    class Triangle : Trapeze
    {
        public Triangle(Point first, Point second, Point third) : base (first, second, third, third) { }

        protected override void validatePoints()      
        {

            double temp1 = (third.X - first.X) * (second.Y - first.Y);
            double temp2 = (third.Y - first.Y) * (second.X - first.X);

            if (temp1 == temp2)
            {
                throw new My_Exceptions.PointCoincidenceException("It is not a Triangle!!! There is a Point-and-Line Coincidence.\n\n");
            }
        }
        
        public override string ToString()
        {
            return string.Format(
                "\n ____________ TRIANGLE ____________  \n Three points :  A{0} B{1} C{2} \n\n \n Side 1 = {3}; \n Side 2 =  {4}; \n Side 3 = {5}; \n\n AREA = {6};\n PERIMETER = {7};"
                ,first, second, third, Basis1, Side1, Side2, Area, Perimeter );
        }
    }
}


