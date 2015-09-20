using System;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a casino table for playing to card game - "Black Jack" or "21".
    /// </summary>
    interface ITable
    {
        /// <summary>
        /// Minimal permissible bet.
        /// </summary>
        int MinBet { get; set; }


        /// <summary>
        /// Maximal permissible bet.
        /// </summary>
        int MaxBet { get; set; }


        /// <summary>
        /// Player's score.
        /// </summary>
        int MyScore { get; set; }


        /// <summary>
        /// Shuffler's score.
        /// </summary>
        int ShufflerScore { get; set; }


        /// <summary>
        /// This method repesents a shuffler who manage a game.
        /// </summary>
        /// <param name="myPurse"></param>       
        void UserMenu(ref double myPurse, int tableNumber);
    }
}
