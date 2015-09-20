using System;
using System.Collections.Generic;
using System.Linq;

namespace geiko.DZ_52.Structs
{
    struct Request : ui.IRequest
    {
        private string Code;
        private Client Client;
        private DateTime Day;
        private List<RequestItem> ItemList;
        private PayType Payment;

        public enum PayType
        {
            Cash, Check, Credit
        }

        public float Sum
        {
            get
            {
                float Sum = 0;
                foreach (Structs.RequestItem item in ItemList)
                {
                    Sum += item.Quantity * item.RequestArticle.Price;
                }
                return Sum;
            }
        }  

        public Request(string Code, Client Client, Request.PayType Payment, List<RequestItem> ItemList)
        {
            this.Code = Code;
            this.Client = Client.DeepCopy(Client);
            this.Day = DateTime.Today;
            this.ItemList = ItemList.Select(item => (RequestItem)item.DeepCopy(item)).ToList();
            this.Payment = Payment;
        }

        public void PrintRequest()
        {
            Console.WriteLine("\n #{0} - {2}\n\n{1} \n\n Payment: {3} \n", Code, Client, Day.ToString("yyyy/MM/dd"), Payment);
            uint i = 0;
            foreach (Structs.RequestItem item in ItemList)
            {
                i++;
                Console.WriteLine("{0}.{1}", i, item);
            }
            Console.WriteLine("\nTotal Sum = {0}", Sum);
        }
    }
}
