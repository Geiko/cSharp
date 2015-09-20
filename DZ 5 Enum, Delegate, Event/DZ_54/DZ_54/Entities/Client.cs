using System;
using System.ComponentModel;

namespace geiko.DZ_54.Entities
{
    class Client : Person
    {
        public Client(string Name) : base(Name) { }


        public Client(string Name, Catalogue library): base(Name) 
        {
            this.Name = Name;
            for (int i = 0; i < library.catalogue.Count; i++)
            {
                library.catalogue[i].PropertyChanged += Client_OnAvailableChanged;
            }
        }
        

        public static void Client_OnAvailableChanged(object sender, PropertyChangedEventArgs e)
        {            
            Console.WriteLine("\nI'v got library message! {1} is {0}\n", e.PropertyName, sender.ToString());
        }


        public new Client DeepCopy(Person current)
        {
            return new Client(current.Name);
        }
    }
}
