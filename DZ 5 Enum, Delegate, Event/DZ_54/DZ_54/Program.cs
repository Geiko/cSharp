/*
Задание 4. 
 
Интерфейс  INotifyPropertyChanged  пространства  имен 
System.ComponentModel определяет, что наследник содержит событие PropertyChanged, 
оповещающее  об  изменении  свойств  объекта.  Изучить  данный  интерфейс,  используя 
MSDN Library. 
 
  Проанализировав  работу  общественных  библиотек  разработать  классы: 
Author, Book, Client, LibraryCard, Catalogue.  

 Описать их поля, 
 поля инкапсулировать свойствами 
 и для классов реализовать интерфейс INotifyPropertyChanged.
 
 Создать диаграмму классов. 
 */

using System;

namespace geiko.DZ_54
{
    class Program
    {
        static void Main(string[] args)
        {
            Entities.Catalogue library = new Entities.Catalogue("CITY PUBLIC LIBRARY");

            library.catalogue.Add(new Entities.Book((new Entities.Author("Jack London")), "Love of Life"));
            library.catalogue.Add(new Entities.Book((new Entities.Author("Jack London")), "Klondike Gold Rush"));
            library.catalogue.Add(new Entities.Book((new Entities.Author("Jack London")), "The Call of the Wild"));
            library.catalogue.Add(new Entities.Book((new Entities.Author("Ray Bradbury")), "A Sound of Thunder"));
            library.catalogue.Add(new Entities.Book((new Entities.Author("JEROME K. JEROME")), "THREE MEN IN A BOAT"));
            library.catalogue.Add(new Entities.Book((new Entities.Author("Francis Scott Fitzgerald")), "THE DIAMOND AS BIG AS THE RITZ"));
            library.catalogue.Add(new Entities.Book((new Entities.Author("O. Henry")), "The Ransom of Red Chief"));

            library.clientCards.Add(new Entities.LibraryCard(new Entities.Client("Vasya Pupcin", library), library));
            library.clientCards.Add(new Entities.LibraryCard(new Entities.Client("Fedor Tupcin", library), library));
            library.clientCards.Add(new Entities.LibraryCard(new Entities.Client("Kolya Bupcin", library), library));

            library.ShowCatalogue();
            
            try
            {
                GiveOut( 5, "Vasya Pupcin", library );
                GiveOut( 2, "Vasya Pupcin", library );
                GiveOut( 6, "Kolya Bupcin", library );

                library.ShowCatalogue();

                GetBack( 6, "Kolya Bupcin", library );
                GetBack( 2, "Vasya Pupcin", library );
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            finally
            {
                library.ShowCatalogue();
            }

            Console.ReadKey();
        }




        static void GetBack(int bookIndex, string clientName, Entities.Catalogue library)
        {
            if (bookIndex > library.catalogue.Count || bookIndex < 0)
                throw new ArgumentOutOfRangeException("\n\nI can't take the book. bookIndex is out of range of catalogue.");

            Entities.Book book = library.catalogue[bookIndex];

            if (book.Available == true)
                throw new Exceptions.UnAvailableBookException("\n\nI can't take the book. This book is available already!!!");
            
            Entities.LibraryCard card = library.clientCards.Find(item => item.Reader.Name == clientName);

            if (card == null)
                throw new Exceptions.InexistentClientException("\n\nI can't take the book. There is no such Client! ");
            else
            {
                book.Available = true;
                Boolean rezult = card.clientBookList.Remove(book);
                if (rezult == false)
                    throw new Exceptions.NoCardRecordException("\n\nI can't take the book. Client did not take the book!!!");
            }
        }


        static void GiveOut(int bookIndex, string clientName, Entities.Catalogue library)
        {
            if (bookIndex > library.catalogue.Count || bookIndex < 0)
                throw new ArgumentOutOfRangeException("\n\nI can't give out the book. bookIndex is out of range of catalogue.");
                      
            Entities.Book book = library.catalogue[bookIndex];

            if (book.Available == false)
                throw new Exceptions.UnAvailableBookException("\n\nI can't give out the book. This book is given out!!!");

            Entities.LibraryCard card = library.clientCards.Find(item => item.Reader.Name == clientName);

            if(card == null)
                throw new Exceptions.InexistentClientException("\n\nI can't give out the book. There is no such Client! ");
            else
            {
                book.Available = false;
                card.clientBookList.Add(book, DateTime.Today);
            }
        }


    }
}
