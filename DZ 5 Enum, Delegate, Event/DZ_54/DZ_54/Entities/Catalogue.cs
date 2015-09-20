using System;
using System.Collections.Generic;

namespace geiko.DZ_54.Entities
{
    class Catalogue
    {
        public string Name { get; set; }
        public List < LibraryCard > clientCards;
        public List < Book > catalogue;



        public Catalogue(string Name)
        {
            this.Name = Name;
            this.catalogue = new List<Book>();
            this.clientCards = new List<LibraryCard>();
        }



        public void ShowCatalogue()
        {
            Console.WriteLine("\n\n\n\n\n{0} : There are {1} books and {2} clients.\n", Name, catalogue.Count, clientCards.Count);
            var i = 0;
            foreach (Book item in catalogue)
            {
                if (item.Available == true) Console.WriteLine("  {0}. {1}", i, item);
                else Console.WriteLine("- {0}. {1}", i, item);
                i++;
            }
            Console.WriteLine();
            var j = 0;
            foreach (LibraryCard card in clientCards)
            {
                if (card.clientBookList.Count != 0) Console.WriteLine("  {0}. {1}  has taken {2} books", j, card.Reader, card.clientBookList.Count);
                else Console.WriteLine("  {0}. {1} ", j, card.Reader);
                j++;
            }
            Console.WriteLine("\n");
        }
    }
}
