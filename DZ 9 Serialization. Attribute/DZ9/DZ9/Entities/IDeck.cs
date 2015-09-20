using System;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a deck of playing cards.
    /// </summary>
    interface IDeck
    {
        /// <summary>
        /// This method randomly shuffles this deck.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// This method takes top card from this deck. 
        /// </summary>
        /// <returns>Top card from this deck.</returns>
        ICard Pop();

        /// <summary>
        /// This method outputs this deck to Console.
        /// </summary>
        void PrintDeck();

        /// <summary>
        /// This method adds a card into this deck.
        /// </summary>
        /// <param name="card"></param>
        void Add(ICard card);
    }
}
