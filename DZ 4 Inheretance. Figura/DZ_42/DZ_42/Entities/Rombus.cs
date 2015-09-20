using System;

namespace geiko.DZ_42.entities
{
    class Rombus : Parallelogram
    {
        public Rombus(Point first, Point second, Point third, Point fourth) : base(first, second, third, fourth) { }
        
        protected override void validatePoints()
        {
            if (isParallel() == false)
            {
                throw new My_Exceptions.NotParallelSidesException("It is not a Rombus!!! There is no pair of parallel sides.\n\n");
            }

            if (Basis1 != Side1  )
            {
                throw new My_Exceptions.NotEqualSidesException("It is not a Rombus!!! The sides are not equal.\n\n");
            }

            if (Basis1 == 0 || Basis2 == 0 || Side1 == 0 || Side2 == 0)
            {
                throw new My_Exceptions.PointCoincidenceException("It is not a Rombus!!! There is a Point Coincidence.\n\n");
            }
        }

        public override string ToString()
        {
            return string.Format(
                "\n ____________ ROMBUS ____________ \n Four points :  A{0} B{1} C{2} D{3} \n\n Side 1 = {4};\n Side 2 = {5}; \n Side 3 = {6};\n Side 4 = {7};  \n\n AREA = {8};\n PERIMETER = {9};"
                , first, second, third, fourth, Basis1, Basis2, Side1, Side2, Area, Perimeter);
        }
    }
}
