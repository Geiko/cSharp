/*
    Задание 3. 
  
   Реализовать метод, который осуществляет поиск элемента в массиве. 
Метод должен принимать массив Object[] array , в котором должен осуществляться поиск, 
и делегат, определяющий, является ли элемент искомым. 
*/

using System;

namespace geiko.DZ_53
{
    class Program
    {
        public struct Article
        {
            public string Code;
            public string Name;
            public float Price;
            public ArticleType Type;

            public enum ArticleType
            {
                Sport, Foods, Clothes, Furniture
            }

            public Article(string Code, string Name, float Price, Article.ArticleType Type)
            {
                this.Code = Code;
                this.Name = Name;
                this.Price = Price;
                this.Type = Type;
            }
            
            public override string ToString()
            {
                return string.Format(" {3}  \t (#{0}) \t {1} \t ${2}", Code, Name, Price, Type);
            }
        }
       
        static public void Find(Object[] array, Comparer comparer)
        {
            for(int i=0; i<array.Length; ++i)
            {
                if (comparer(array[i]))
                {
                    Console.WriteLine("\n Rezult: index = {0}\n{1}", i, array[i]);
                }
            }
        }

        public delegate Boolean Comparer(Object elem1);

        static public Boolean CodeComparer(Object goods)
        {
            return ((Article)goods).Code == "lu385";
        }

        static public Boolean TypeComparer(Object goods)
        {
            return ((Article)goods).Type == Article.ArticleType.Foods;
        }

        static public Boolean NameComparer(Object goods)
        {
            return ((Article)goods).Name == "T-shirt";
        }

        static void Main(string[] args)
        {
            Article goods1 = new Article("375g", "Orange", 12.5F, Article.ArticleType.Foods);
            Article goods2 = new Article("375s", "T-shirt", 20.90F, Article.ArticleType.Sport);
            Article goods3 = new Article("ak1598", "Red Apples", 4.20F, Article.ArticleType.Foods);
            Article goods4 = new Article("lu385", "Marine Hat", 14.62F, Article.ArticleType.Clothes);
            Article goods5 = new Article("g654", "Tea Table", 330F, Article.ArticleType.Furniture);
            Article goods6 = new Article("375s", "T-shirt", 20.90F, Article.ArticleType.Sport);

            Object[] GoodsArray = { goods1, goods2, goods3, goods4, goods5, goods6 };
            uint i = 0;
            foreach (Object goods in GoodsArray)
            {
                Console.WriteLine("{0}.{1}", i, goods);
                i++;
            }

            Console.WriteLine("\n\n\nFind Code of Article \"lu385\" -");
            Find(GoodsArray, new Comparer(CodeComparer));

            Console.WriteLine("\n\n\nFind Type of Article \"Foods\" -");
            Find(GoodsArray, new Comparer(TypeComparer));

            Console.WriteLine("\n\n\nFind Name of Article \"T-shirt\" -");
            Find(GoodsArray, new Comparer(NameComparer));

            Console.ReadKey();
        }
    }
}