using System;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a playing card.
    /// </summary>
    class Card : ICard
    {
//        [NonSerialized]

        /// <summary>
        /// This fild keeps a value of this card suit.
        /// </summary>
        private Suits suit;

        /// <summary>
        /// This fild keps a value of this card significance.
        /// </summary>
        private Significances significance;

        /// <summary>
        /// This is a constructor of this card.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="significance"></param>
        public Card(Suits suit, Significances significance)
        {
            this.suit = suit;
            this.significance = significance;
        }


        /// <summary>
        /// This property admits to get a suit of this card.
        /// </summary>
        public Suits Suit 
        { 
            get { return suit; } 
        }

        /// <summary>
        /// This property admits to get a significance of this card.
        /// </summary>
        public Significances Significance 
        { 
            get { return significance; } 
        }

        /// <summary>
        /// This method overrides the ToString method in order to provide information about this card.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("   {1, -8} {0} ", Suit, Significance);
        }
    }
}
