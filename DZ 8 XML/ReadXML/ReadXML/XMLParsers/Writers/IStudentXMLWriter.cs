using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXML
{
    /// <summary>
    ///It writes XML document to file "newStudent".
    /// </summary>
    interface IStudentXMLWriter
    {
        /// <summary>
        /// Write of student's data to file.
        /// </summary>
        /// <param name="students">Collection of students.</param>
        /// <param name="filePath">Path to file for writing.</param>
        /// <exceptions>XmlException</exceptions>      
        void WriteAll(ICollection<Student> students, string filePath);
    }
}
