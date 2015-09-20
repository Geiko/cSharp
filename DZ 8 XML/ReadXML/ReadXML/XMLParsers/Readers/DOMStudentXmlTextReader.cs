using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadXML
{
    /// <summary>
    /// IStudentXMLReader implementation using XmlTextReader.
    /// </summary>
    class DOMStudentXmlTextReader : IStudentXMLReader
    {
        /// <summary>
        /// Reads Xml files with XmlTetReader.
        /// </summary>
        /// <param name="filePath">Path of a file for reading.</param>
        /// <returns>Collection of students.</returns>
        /// <exceptions>XmlException</exceptions>      
        public ICollection<Student> ReadAll(string filePath)
        {
            List<Student> rezult = new List<Student>();
            
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("files\\students.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;

                while (reader.Read())
                    if (reader.Name == "student")
                        rezult.Add(FormStudent(reader));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }  

            return rezult;
        }

        /// <summary>
        /// Creates Student instance from XmlTextReader.
        /// </summary>
        /// <param name="reader">Instance of XmlTextReader.</param>
        /// <returns>Instance of student.</returns>
        private Student FormStudent(XmlTextReader reader)
        {
            Student student = new Student();

            while (reader.MoveToNextAttribute())
            {
                if (reader.Name == "login")
                    student.Login = reader.Value;
                else if (reader.Name == "faculty")
                    student.Faculty = reader.Value;
            }

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement() == true)
                {
                    switch (reader.Name)
                    {
                        case "name":
                            student.Name = reader.ReadString();
                            break;
                        case "phone":
                            student.Phone = reader.ReadString();
                            break;
                        case "address":
                            student.Address = FormAddress(reader);
                            break;
                    }
                }
                else if (reader.Name == "student" && reader.IsStartElement() == false)
                    return student;
            }
            return student;
        }

        /// <summary>
        /// Creates Address instance from XmlTextReader.
        /// </summary>
        /// <param name="reader">Instance of XmlTextReader.</param>
        /// <returns>Instance of address.</returns>
        private Address FormAddress(XmlTextReader reader)
        {
            Address address = new Address();
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "country":
                        address.Country = reader.ReadString();
                        break;
                    case "city":
                        address.City = reader.ReadString();
                        break;
                    case "street":
                        address.Street = reader.ReadString();
                        break;
                }
                if (reader.Name == "address" && reader.IsStartElement() == false)
                    return address;
            }
            return address;
        }
    }
}
