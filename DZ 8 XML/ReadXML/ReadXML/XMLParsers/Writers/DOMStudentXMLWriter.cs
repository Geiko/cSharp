using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadXML
{
    /// <summary>
    ///It writes XML document to file "newStudent".
    /// </summary>
    class DOMStudentXMLWriter: IStudentXMLWriter
    {
        /// <summary>
        /// Write of student's data to file.
        /// </summary>
        /// <param name="students">Collection of students.</param>
        /// <param name="filePath">Path to file for writing.</param>
        /// <exceptions>XmlException</exceptions>      
        void IStudentXMLWriter.WriteAll(ICollection<Student> students, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

            doc.AppendChild(declaration);

            //TODO вынести в константы имена элементов, пронстранств имен и т.д.
            //XmlElement root = new XmlElement("tns", "students", "http://itstep.org/students", null);
            XmlElement root = doc.CreateElement("tns", "students", "http://itstep.org/students");
            XmlAttribute schemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
            schemaLocation.Value = "http://itstep.org/students students.xsd";
            root.Attributes.Append(schemaLocation);

            foreach (var student in students)
            {
                root.AppendChild(SerializeStudent(student, doc));
            }

            doc.AppendChild(root);
            doc.Save(filePath);
        }

        /// <summary>
        /// Create a document node of student that represent student's instance in xml format.
        /// </summary>
        /// <param name="student">Instance of a student.</param>
        /// <param name="doc">Instance of an xml document.</param>
        /// <returns>Student's node.</returns>
        private XmlNode SerializeStudent(Student student, XmlDocument doc)
        {
            XmlElement studentElement = doc.CreateElement("student");

            //Creating and appending attributes
            XmlAttribute login = doc.CreateAttribute(ConstantNames.ATTR_LOGIN);
            login.Value = student.Login;
            studentElement.Attributes.Append(login);
            XmlAttribute faculty = doc.CreateAttribute(ConstantNames.ATTR_FACULTY);
            faculty.Value = student.Faculty;
            studentElement.Attributes.Append(faculty);

            //Creating and appending elements
            XmlElement name = doc.CreateElement("name");
            name.AppendChild(doc.CreateTextNode(student.Name));
            studentElement.AppendChild(name);

            XmlElement phone = doc.CreateElement("phone");
            phone.AppendChild(doc.CreateTextNode(student.Phone));
            studentElement.AppendChild(phone);

            AddressCreate(student, doc, studentElement);

            return studentElement;
        }

        /// <summary>
        /// Creating and appending elements of address.
        /// </summary>
        /// <param name="student">Instance of a student.</param>
        /// <param name="doc">Instance of a document.</param>
        /// <param name="studentElement">Node of a student.</param>
        private void AddressCreate(Student student, XmlDocument doc, XmlElement studentElement)
        {
            XmlElement address = doc.CreateElement("address");
            studentElement.AppendChild(address);

            XmlElement country = doc.CreateElement("country");
            country.AppendChild(doc.CreateTextNode(student.Address.Country));
            address.AppendChild(country);

            XmlElement city = doc.CreateElement("city");
            city.AppendChild(doc.CreateTextNode(student.Address.City));
            address.AppendChild(city);

            XmlElement street = doc.CreateElement("street");
            street.AppendChild(doc.CreateTextNode(student.Address.Street));
            address.AppendChild(street);
        }
    }
}
