using System;

namespace geiko.DZ_52.Structs
{
    struct Client
    {
        private string Code;
        private string Name;
        private string Address;
        private string Phone;
        private uint OrdersQuantity;
        private float TotalOrdersSum;
        private ClientType Type;

        public enum ClientType
        {
            Inconsiderable, So_So, Significant, Topmost
        }
        
        public Client(string Code, string Name, string Address, string Phone, uint OrdersQuantity, float TotalOrdersSum)
        {
            this.Code = Code;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.OrdersQuantity = OrdersQuantity;
            this.TotalOrdersSum = TotalOrdersSum;

            if (this.TotalOrdersSum < 1000)
            {
                this.Type = ClientType.Inconsiderable;
            }
            else if(this.TotalOrdersSum > 1000 && this.TotalOrdersSum <= 5000)
            {
                this.Type = ClientType.So_So;
            }
            else if (this.TotalOrdersSum > 5000 && this.TotalOrdersSum <= 25000)
            {
                this.Type = ClientType.Significant;
            }
            else
            {
                this.Type = ClientType.Topmost;
            }
        }

        public Client DeepCopy(Client currentClient)
        {
            Client newClient = new Client();

            newClient.Code = currentClient.Code;
            newClient.Name = currentClient.Name;
            newClient.Address = currentClient.Address;
            newClient.Phone = currentClient.Phone;
            newClient.OrdersQuantity = currentClient.OrdersQuantity;
            newClient.TotalOrdersSum = currentClient.TotalOrdersSum;
            newClient.Type = currentClient.Type;

            return newClient;
        }

        public override string ToString()
        {
            return string.Format(" #{0} {1} \n {2} {3} \n Orders Quantity={4}, Total=${5}, \n Client Type - {6}. ",
                Code, Name, Address, Phone, OrdersQuantity, TotalOrdersSum, Type);
        }
    }
}
