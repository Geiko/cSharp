/*
Задание 1. -------------------------------------------------------------
 
Описать структуру Article, содержащую следующие поля: 
 * код товара; 
 * название товара;
 * цену товара. 
 
Описать структуру Client содержащую поля: 
 * код клиента; 
 * ФИО; 
 * адрес; 
 * телефон; 
 * количество заказов осуществленных клиентом; 
 * общая сумма заказов клиента. 
 
Описать структуру RequestItem содержащую поля: 
 * товар; 
 * количество единиц товара. 
 
Описать структуру Request содержащую поля: 
 * код заказа; 
 * клиент;  
 * дата заказа; 
 * перечень заказанных товаров; 
 * сумма заказа (реализовать вычисляемым свойством). 
 
 
Задание 2. ------------------------------------------------------------------------------
 
Описать перечисление ArticleType определяющее типы товаров, и доба-
вить соответствующее поле в структуру Article из задания №1; 
 
Описать перечисление ClientType определяющее важность клиента, и добавить соответ-
ствующее поле в структуру Client из задания №1; 
 
Описать перечисление PayType определяющее форму оплаты клиентом заказа, и добавить 
соответствующее поле в структуру Request из задания №1; 

*/

using System;
using System.Collections.Generic;

namespace geiko.DZ_52
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\nARTICLE");
            Structs.Article commodity1 = new Structs.Article("ak1598", "Red Apples", 4.20F, Structs.Article.ArticleType.Foods);
            Structs.Article commodity2 = new Structs.Article("lu385", "Marine Hat", 14.62F, Structs.Article.ArticleType.Clothes);
            Structs.Article commodity3 = new Structs.Article("g654", "Tea Table", 330F, Structs.Article.ArticleType.Furniture);
            Console.WriteLine(commodity1);
            Console.WriteLine(commodity2);
            Console.WriteLine(commodity3);


            Console.WriteLine("\n\n\nCLIENT");
            Structs.Client client1 = new Structs.Client("214", "Vasya Pupkin", "Forbes ave.,37,7,Sacramento,CA", "(661) 664-2011", 10, 1340);
            Console.WriteLine(client1);


            Console.WriteLine("\n\n\nREQUEST ITEM");
            Structs.RequestItem item1 = new Structs.RequestItem(commodity1, 3);
            Console.WriteLine(item1);



            Console.WriteLine("\n\n\nREQUEST-------------------------------------");

            List<Structs.RequestItem> ItemList1 = new List<Structs.RequestItem>();
            ItemList1.Add(item1);
            ItemList1.Add(new Structs.RequestItem() { RequestArticle = commodity2, Quantity = 1 });
            ItemList1.Add(new Structs.RequestItem() { RequestArticle = commodity3, Quantity = 2 });

            Structs.Request request1 = new Structs.Request("6534", client1, Structs.Request.PayType.Cash, ItemList1); 
            request1.PrintRequest();

            Console.ReadKey();
        }
    }
}
