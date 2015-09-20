/*
4.  Разработайте приложение “7 чудес света”, где каждое чудо будет 
представлено  отдельным  классом.  Создайте  дополнительный  класс, 
содержащий точку входа. Распределите приложение по файлам проекта 
и с помощью пространства имён обеспечьте возможность взаимодействия 
классов. */

using System;

namespace geiko.DZ_34
{
    class EnterPoint
    {
        static void Main()
        {
            WorldMiracle first = new WorldMiracle();
            WorldMiracle second = new WorldMiracle();
            WorldMiracle third = new WorldMiracle();
            WorldMiracle fourth = new WorldMiracle();
            WorldMiracle fifth = new WorldMiracle();
            WorldMiracle sixth = new WorldMiracle();
            WorldMiracle seventh = new WorldMiracle();

            first.Name = "Great Pyramid of Giza";
            second.Name = "Hanging Gardens of Babylon";
            third.Name = "Statue of Zeus at Olympia";
            fourth.Name = "Temple of Artemis at Ephesus";
            fifth.Name = "Mausoleum at Halicarnassus";
            sixth.Name = "Colossus of Rhodes";
            seventh.Name = "Lighthouse of Alexandria";

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tWorld miracles:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n1) {0}\n2) {1}\n3) {2}\n4) {3}\n5) {4}\n6) {5}\n7) {6}", first.Name, second.Name, third.Name, fourth.Name, fifth.Name, sixth.Name, seventh.Name);
            
            Console.Beep();
            Console.SetWindowSize(32, 16);
            Console.SetBufferSize(32, 16); 
            Console.ReadKey();
        }
    }
}
