using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXML
{
    /// <summary>
    /// Reads XML file.
    /// </summary>
    interface IStudentXMLReader
    {
        /// <summary>
        /// Reads xml file from disk and returns a collection of objects(Students).
        /// </summary>
        /// <param name="filePath">Path to a file.</param>
        /// <returns>Collection of students.</returns>
        /// <exceptions>XmlException</exceptions>      
        ICollection<Student> ReadAll(string filePath);
    }
}
