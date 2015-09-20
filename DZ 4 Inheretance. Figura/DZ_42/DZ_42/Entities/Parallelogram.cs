using System;

namespace geiko.DZ_42.entities
{
    class Parallelogram : Trapeze
    {
        public Parallelogram(Point first, Point second, Point third, Point fourth) : base(first, second, third, fourth) { }
        
        protected override void validatePoints()
        {
            if (isParallel() == false)         
            {
                throw new My_Exceptions.NotParallelSidesException("It is not a Parallelogram!!! There is no pair of parallel sides.\n\n");
            }

            if (Basis1 == 0 || Basis2 == 0 || Side1 == 0 || Side2 == 0)
            {
                throw new My_Exceptions.PointCoincidenceException("It is not a Parallelogram!!! There is a Point Coincidence.\n\n");
            }
        }

        protected bool isParallel()                
        {
            bool flag = false;

            if ((first.Y - second.Y) * (third.X - fourth.X) == (third.Y - fourth.Y) * (first.X - second.X) &&
                (first.Y - third.Y) * (second.X - fourth.X) == (second.Y - fourth.Y) * (first.X - third.X)) flag = true;

            else if ((first.Y - second.Y) * (third.X - fourth.X) == (third.Y - fourth.Y) * (first.X - second.X) &&
                (first.Y - fourth.Y) * (third.X - second.X) == (third.Y - second.Y) * (first.X - fourth.X)) flag = true;

            else if ((first.Y - third.Y) * (second.X - fourth.X) == (second.Y - fourth.Y) * (first.X - third.X) &&
                (first.Y - fourth.Y) * (second.X - third.X) == (second.Y - third.Y) * (first.X - fourth.X)) flag = true;

            return flag;
        }
        
        public override string ToString()
        {
            return string.Format(
                "\n ____________ PARALLELOGRAM ____________ \n Four points :  A{0} B{1} C{2} D{3} \n\n Side 1 = {4};\n Side 2 = {5}; \n Side 3 = {6};\n Side 4 = {7};  \n\n AREA = {8};\n PERIMETER = {9};"
                , first, second, third, fourth, Basis1, Basis2, Side1, Side2, Area, Perimeter);
        }
    }
}
            