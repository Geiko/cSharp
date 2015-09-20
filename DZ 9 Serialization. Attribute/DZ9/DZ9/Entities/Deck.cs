using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a deck of playing cards.
    /// </summary>
    class Deck : IDeck
    {
        /// <summary>
        /// It is a list of playing cards of this deck.
        /// </summary>
        public List<ICard> pack;

        
        /// <summary>
        /// It is constructor of this deck.
        /// </summary>
        public Deck()
        {
            this.pack = new List<ICard>();

            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Significances significance in Enum.GetValues(typeof(Significances)))
                {
                    this.pack.Add
                    (
                        new Card(suit, significance)
                    );
                }  
            }
        }


        /// <summary>
        /// This method randomly shuffles this deck.
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < pack.Count; ++i)
            {
                int r = rand.Next(0, pack.Count);
                Swap(i, r, ref pack);
            }
        }


        /// <summary>
        /// This method swaps places of two cards in this deck.
        /// </summary>
        /// <param name="i">current index</param>
        /// <param name="r">random index</param>
        /// <param name="deck">This deck or list of playing cards.</param>
        private void Swap(int i, int r, ref List<ICard> deck)
        {
            ICard temp = deck[i];
            deck[i] = deck[r];
            deck[r] = temp;
        }



        /// <summary>
        /// This method outputs this deck to Console.
        /// </summary>
        public void PrintDeck()
        {
            Console.WriteLine("\n\n");
            for (int i = 0; i < pack.Count; ++i)
            {
                Console.WriteLine(" {0, 3}{1}", i, pack[i]);
            }
            Console.WriteLine("\n\n");
        }


        /// <summary>
        /// This method takes top card from this deck. 
        /// </summary>
        /// <returns>Top card from this deck.</returns>
        public ICard Pop()
        {
            ICard temp = pack[pack.Count - 1];
            this.pack.RemoveAt(pack.Count - 1);
            return temp;
        }



        /// <summary>
        /// This method adds a card into this deck.
        /// </summary>
        /// <param name="card">A card.</param>
        public void Add(ICard card)
        {
            this.pack.Add(card);
        }
    }
}
