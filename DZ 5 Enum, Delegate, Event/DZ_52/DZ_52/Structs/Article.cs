using System;

namespace geiko.DZ_52.Structs
{
    struct Article 
    {
        private string Code;
        private string Name;
        public float Price;
        private ArticleType Type;

        public enum ArticleType
        {
            HouseholdChemicals, Foods, Clothes, Furniture
        }


        public Article(string Code, string Name, float Price, Article.ArticleType Type)
        {
            this.Code = Code;
            this.Name = Name;
            this.Type = Type;
            this.Price = Price;
        }

        public Article DeepCopy(Article currentArticle)
        {
            Article newArticle = new Article();

            newArticle.Code = currentArticle.Code;
            newArticle.Name = currentArticle.Name;
            newArticle.Price = currentArticle.Price;
            newArticle.Type = currentArticle.Type;

            return newArticle;
        }

        public override string ToString()
        {
            return string.Format(" {3}  \t (#{0}) \t {1} \t ${2}", Code, Name, Price, Type);
        }  

    }
}
