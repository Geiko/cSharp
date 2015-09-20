using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using geiko.exam.Entities;

namespace geiko.exam
{
    /// <summary>
    /// This interface sets methods for the class of menu for users.
    /// </summary>
    interface IUserMenu
    {
        /// <summary>
        /// This method allows a user to choose country, domain, city
        /// and create them
        /// and to edit info city file.
        /// It shoudbe be used a recursion next time.
        /// </summary>
        void ShowGeographyInfo();
    }
}
