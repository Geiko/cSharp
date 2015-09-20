using System;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a playing card.
    /// </summary>
    interface ICard
    {      
        /// <summary>
        /// This property admits to get a suit of a card.
        /// </summary>
        Suits Suit { get; }

        /// <summary>
        /// This property admits to get a value of a card.
        /// </summary>
        Significances Significance { get; }
    }


    /// <summary>
    /// This list catalogs permissible values of Suits.
    /// </summary>
    public enum Suits
    {
        Hearts, Diamonds, Clubs, Spades
    }

    /// <summary>
    /// This list catalogs permissible values of Values.
    /// </summary>
    public enum Significances
    {
        two=2, three=3, four=4, five=5, six=6, seven=7, eight=8, nine=9, ten=10, Jack=10, Queen=10, King=10, Ace=11
    }
}
