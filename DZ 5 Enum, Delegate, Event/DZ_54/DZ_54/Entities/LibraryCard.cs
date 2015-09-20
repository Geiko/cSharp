using System;
using System.Collections.Generic;

namespace geiko.DZ_54.Entities
{
    class LibraryCard
    {
        public Client Reader { get; set; }
        public Dictionary<Book, DateTime> clientBookList;  // DateTime - date of giving out the book



        public LibraryCard(Client reader, Catalogue library)
        {
            this.Reader = reader.DeepCopy(reader);
            this.clientBookList = new Dictionary<Book, DateTime>();
        }



        public void ShowClientCard()
        {
            Console.WriteLine("\nThis is the Card of {0} : {1} books were taken.", Reader.Name, clientBookList.Count);
            var i = 0;
            foreach (KeyValuePair<Book, DateTime> kvp in clientBookList)
            {
                Console.WriteLine(" {0}. {1} -   {2}", i, kvp.Key, kvp.Value.ToString("d"));
                i++;
            }
            
        }
    }
}
