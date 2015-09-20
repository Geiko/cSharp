using System;

namespace geiko.DZ_64
{
    /// <summary> 
    /// Обобщенный класс точки 
    /// </summary> 
    /// <typeparam name="T"> 
    /// координаты точки могут быть любого типа 
    /// </typeparam> 

    class Point2D<T> where T: struct, IComparable<T>
    {
         //параметр типа используется для задания типа переменных класса  
        T x; 
        T y; 
        //параметр типа используется для задания типа свойства 
        public T X 
 
        { 
            get { return x; } 
            set { x = value; } 
        } 
        public T Y 
        { 
            get { return y; } 
            set { y = value; } 
        } 
        //параметр типа используется для задания типов параметров метода 
        public Point2D(T x, T y) 
        { 
            this.x = x; this.y = y; 
        } 

        public Point2D() 
        { 
            this.x = default(T); this.y = default(T); 
        }
    }
}
