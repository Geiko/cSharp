using System;

namespace geiko.DZ_52.Structs
{
    struct RequestItem 
    {
        public Article RequestArticle;
        public uint Quantity;

        public RequestItem(Article RequestArticle, uint Quantity)
        {
            this.RequestArticle = RequestArticle.DeepCopy(RequestArticle);
            this.Quantity = Quantity;
        }

        public override string ToString()
        {
            return string.Format(" {0}\t {1}pcs ", RequestArticle, Quantity);
        }

        public RequestItem DeepCopy(RequestItem current)
        {
            RequestItem copied = new RequestItem();

            copied.RequestArticle = current.RequestArticle.DeepCopy(current.RequestArticle);
            copied.Quantity = current.Quantity;

            return copied;
        }
    }
}
