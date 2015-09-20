using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace geiko.exam.Utilities
{
    /// <summary>
    /// This interface sets methods for fileServis class, that provides working with files and directories.
    /// </summary>
    interface IFileServis
    {
        /// <summary>
        /// This method creates a new file of city info and inserts the info to the manifest.
        /// </summary>
        /// <param name="domain">instance of a domain</param>
        /// <param name="um">instance of user menu</param>
        void createFile(exam.Entities.Domain domain, UserMenu um);
        /// <summary>
        /// This method creates a new folder of domain and adds domain info to the manifest.
        /// </summary>
        /// <param name="country">instance of country</param>
        /// <param name="um">instance of user menu</param>
        void createDomain(exam.Entities.Country country, UserMenu um);
        /// <summary>
        /// This method creates a new folder of country and adds country info to the manifest.
        /// </summary>
        /// <param name="um">instance of user menu</param>
        void createCountry(UserMenu um);
        /// <summary>
        /// This method inserts command of opening editor with loaded file to manifest.
        /// </summary>
        /// <param name="thePath">path to file</param>
        /// <param name="um">instance of user menu</param>
        void writeCommandToManifest(string thePath, UserMenu um);
    }
}
