/*
Реализовать интерфейс 
 * ПростойНУгольник, который имеет свойства: 
Высота, Основание, УголМеждуОснованиемИСмежнойСтороной, КоличествоСторон,  ДлиныСторон, Площадь, Периметр.
*/

using System;

namespace geiko.DZ_42.ui
{
    interface I_Poligon
    {
        double Height { get; }
        double Basis { get; }
        double Angle { get; }
        double SidesQuantity { get; }
        double SidesLength { get; }
        double Area { get; }
        double Perimeter { get; }
    }
}
