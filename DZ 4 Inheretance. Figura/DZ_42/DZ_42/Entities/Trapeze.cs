using System;

namespace geiko.DZ_42.entities
{
    class Trapeze : Figure
    {
        protected Point first;
        protected Point second;
        protected Point third;
        protected Point fourth;
        
        public Trapeze(Point first, Point second, Point third, Point fourth)
        {
            this.first = first.DeepCopy(first);
            this.second = second.DeepCopy(second);
            this.third = third.DeepCopy(third);
            this.fourth = fourth.DeepCopy(fourth);
            validatePoints();      
        }

        protected virtual void validatePoints()       //  Are any two sides parallel?
        {
            bool flag = false;

            if( ( first.Y - second.Y ) * ( third.X - fourth.X ) == ( third.Y - fourth.Y ) * ( first.X - second.X ) ) flag = true;
            else if((first.Y - third.Y ) * ( second.X - fourth.X ) == ( second.Y - fourth.Y ) * ( first.X - third.X )) flag = true;
            else if((first.Y - fourth.Y ) * ( third.X - second.X ) == ( third.Y - second.Y ) * ( first.X - fourth.X )) flag = true;

            if (flag == false)
            {
                throw new My_Exceptions.NotParallelSidesException("It is not a Trapeze!!! There is no parallel sides.\n\n");
            }
            
            if (Basis1 == 0 || Basis2 == 0 || Side1 == 0 || Side2 == 0)
            {
                throw new My_Exceptions.PointCoincidenceException("It is not a Trapeze!!! There is a Point Coincidence.\n\n");
            }
        }

        public double Basis1
        {
            get
            {
                if ((first.Y - second.Y) * (third.X - fourth.X) == (third.Y - fourth.Y) * (first.X - second.X)) return distance(first, second);
                else if ((first.Y - third.Y) * (second.X - fourth.X) == (second.Y - fourth.Y) * (first.X - third.X)) return distance(first, third);
                return distance(first, fourth);
            }
        }

        public double Basis2
        {
            get
            {
                if ((first.Y - second.Y) * (third.X - fourth.X) == (third.Y - fourth.Y) * (first.X - second.X)) return distance(third, fourth);
                else if ((first.Y - third.Y) * (second.X - fourth.X) == (second.Y - fourth.Y) * (first.X - third.X)) return distance(second, fourth);
                return distance(third, second);
            }
        }

        public double Side1
        {
            get
            {
                if ((first.Y - second.Y) * (third.X - fourth.X) == (third.Y - fourth.Y) * (first.X - second.X))
                {
                    if (distance(first, third) > distance(first, fourth)) return distance(first, fourth);
                    return distance(first, third);
                }
                else if ((first.Y - third.Y) * (second.X - fourth.X) == (second.Y - fourth.Y) * (first.X - third.X))
                {
                    if (distance(first, second) > distance(first, fourth)) return distance(first, fourth);
                    return distance(first, second);
                }
                return distance(first, second);
            }
        }

        public double Side2
        {
            get
            {
                if ((first.Y - second.Y) * (third.X - fourth.X) == (third.Y - fourth.Y) * (first.X - second.X)) 
                {
                    if (distance(second, fourth) > distance(second, third)) return distance(second, third);
                    return distance(second, fourth);
                }
                else if ((first.Y - third.Y) * (second.X - fourth.X) == (second.Y - fourth.Y) * (first.X - third.X))
                {
                    if (distance(third, fourth) > distance(second, third)) return distance(second, third);
                    return distance(third, fourth);
                }               
                return distance(third, fourth);
            }
        }

        public override double Area
        {
            get 
            {
                double temp = 0;
                if (Basis1 != Basis2)
                {
                    temp = (Math.Pow((Basis1 - Basis2), 2) + Math.Pow(Side1, 2) - Math.Pow(Side2, 2)) / 2 / (Basis1 - Basis2);
                }
                return (Basis1 + Basis2)/2 * Math.Sqrt( Math.Pow(Side1,2) - Math.Pow(temp,2)); 
            }
        }

        public override double Perimeter
        {
            get { return Basis1 + Basis2 + Side1 + Side2; }
        }

        public override string ToString()
        {
            return string.Format(
                "\n ____________ TRAPEZE ____________ \n Four points :  A{0} B{1} C{2} D{3} \n\n Basis 1 = {4};\n Basis 2 = {5}; \n Side 1 = {6};\n Side 2 = {7};  \n\n AREA = {8};\n PERIMETER = {9};"
                ,first, second, third, fourth, Basis1, Basis2, Side1, Side2, Area, Perimeter);
        }
    }
}


            