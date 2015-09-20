using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXML
{
    /// <summary>
    /// Reads XML file
    /// </summary>
    interface IXmlReader
    {
        /// <summary>
        /// Reads xml file from disk and returns it in string format.
        /// </summary>
        /// <param name="filePath">Path to xml file.</param>
        /// <returns>Xml in string form.</returns>
        /// <exception cref="System.IO.FileNotFoundException">When file can not be opened</exception>
        string readXml(string filePath);
    }
}
