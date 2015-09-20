using System;

namespace geiko.DZ_37
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction (int x, int y)
        {
            numerator = x;
            denominator = y;
        }

        public override string ToString()
        {
            return string.Format(" ({0} / {1})", numerator, denominator);
        }

        public static Fraction operator * (Fraction a, int b)
        {
            return new Fraction(a.numerator * b , a.denominator);
        }

        public static Fraction operator * (int a, Fraction b)
        {
            return b * a;
        }

        public static implicit operator Fraction(double d)
        {
            int integerPart = (int)d;
            Fraction @int = new Fraction(integerPart, 1);

            double fractionalPart = d - integerPart;
            string fractPartStr = Convert.ToString(fractionalPart);
            int counter = 0;
            for(int i=0; i<fractPartStr.Length; i++)
            {
                counter++;
                if(fractPartStr[i] == ',') counter = 0;       
            }
            Fraction @fraction = new Fraction((int)(fractionalPart * 10), counter * 10);
            return @int + @fraction;
        }

        public static Fraction operator + (Fraction a, Fraction b)
        {
            Fraction z = new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);

            while (true)
            {
                if (z.numerator % 10 == 0 && z.denominator % 10 == 0)
                {
                    z.numerator = z.numerator / 10;
                    z.denominator = z.denominator / 10;
                }
                else break;
            }
            return z;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction temp = new Fraction(b.denominator, b.numerator);
            return a * temp;
        }


        //Перегрузка метода Equals ------------------------------------------------------
        public override bool Equals(object obj)
        {
            //если obj == null, 
            //значит он != объекту, от имени которого вызывается этот метод 
            if (obj == null) return false;
            Fraction p = obj as Fraction;
            //переданный объект не является ссылкой на Fraction 
            if (p == null) return false;
            //проверяется равенство содержимого 
            return ((numerator == p.numerator) && (denominator == p.denominator));
        }

        //При перегрузке Equals надо также перегрузить GetHashCode() 
        public override int GetHashCode()
        {
            return numerator ^ denominator;//использование XOR для получения хеш кода 
        }

        public static bool operator ==(Fraction p1, Fraction p2)
        {
            //проверка, что переменные ссылаются на один и тот же адрес 
            //сравнение p1 == p2 приведет к бесконечной рекурсии 
            if (ReferenceEquals(p1, p2)) return true;
            //приведение к object необходимо,  
            //т.к. сравнение p1 == null приведет к бесконечной рекурсии 
            if ((object)p1 == null) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Fraction p1, Fraction p2)
        {
            return (!(p1 == p2));
        }         //--------------------------------------------------------------------------------

    }
}
