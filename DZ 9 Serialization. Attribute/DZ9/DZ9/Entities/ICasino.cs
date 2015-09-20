using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.DZ9.Entities
{
    /// <summary>
    /// This class represents a casino - an array of playing tables.
    /// </summary>
    interface ICasino
    {
        /// <summary>
        /// This method allows player to select a table and serialize data.
        /// </summary>
        /// <param name="myPurse">It is money($) in purse of player.</param>
        void SelectTable(double myPurse);
    }
}
