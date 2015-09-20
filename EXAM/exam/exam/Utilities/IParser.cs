using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using geiko.exam.Entities;
using System.IO;
using System.Text.RegularExpressions;

namespace geiko.exam.Utilities
{
    /// <summary>
    /// This interface sets methods for Parser class to parse manifest and to create instansies of entity classes;
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// This method allows to read a manifest file.
        /// </summary>
        /// <param name="manifestPath">path to file of manifest</param>
        /// <param name="countries">list of country instancies</param>
        /// <param name="um">instance of user menu</param>
        void parse(string manifestPath, List<Country> countries, UserMenu um);  
    }
}
