using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko
{
    class Complex
    {
        private decimal x;        
        private decimal y;

        public Complex(decimal x, decimal y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format(" {0} + i {1};", x, y);
        } 

        public static Complex operator * (Complex a, Complex b)
        {
            return new Complex(a.x * b.x - a.y * b.y,   a.y * b.x + a.x * b.y);
        }

        public static Complex operator * (decimal a, Complex b)
        {
            return new Complex(a * b.x, a * b.y);
        }

        public static Complex operator * (Complex b, decimal a)
        {
            return a * b;
        }

        public static Complex operator / (Complex a, Complex b)
        {
            return new Complex((a.x * b.x + a.y * b.y) / (b.x * b.x + b.y * b.y), (a.y * b.x - a.x * b.y) / (b.x * b.x + b.y * b.y));
        }

        public static Complex operator - (Complex a, decimal b)
        {
            return new Complex(a.x - b, a.y - b);
        }
        
        public static Complex operator - (Complex a, Complex b)
        {
            return new Complex(a.x - b.x, a.y - b.y);
        }
    }
}
