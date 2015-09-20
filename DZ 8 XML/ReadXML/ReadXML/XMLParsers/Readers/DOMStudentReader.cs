using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadXML
{
    /// <summary>
    /// IStudentXMLReader implementation using DOM API
    /// </summary>
    class DOMStudentReader: IStudentXMLReader
    {
        /// <summary>
        /// Reads xml file from disk and returns a collection of objects(Students).
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <returns>List of students.</returns>
        /// <exceptions>XmlException</exceptions>      
        public ICollection<Student> ReadAll(string filePath)
        {
            List<Student> result = new List<Student>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            var root = doc.DocumentElement;
            XmlNodeList childNodes = root.ChildNodes;
            foreach (XmlNode node in childNodes)
            {
                result.Add(FormStudent(node));
            }

            return result;
        }

        /// <summary>
        /// Creates Student instance from XmlNode that represents a student in xml format.
        /// </summary>
        /// <param name="node">XmlNode that represents a student in xml format.</param>
        /// <returns>Created student.</returns>
        private Student FormStudent(XmlNode node)
        {
            Student result = new Student();
            result.Login = node.Attributes[ConstantNames.ATTR_LOGIN].Value;
            result.Faculty = node.Attributes[ConstantNames.ATTR_FACULTY].Value;
            result.Name = node.ChildNodes[ConstantNames.NODE_NAME_INDEX].FirstChild.Value;
            result.Phone = node.ChildNodes[ConstantNames.NODE_PHONE_INDEX].FirstChild.Value;
            XmlNode addressNode = node.ChildNodes[ConstantNames.NODE_ADDRESS_INDEX];
            result.Address = FormAddress(addressNode);
            return result;
        }

        /// <summary>
        /// Creates Address instance from XmlNode that represents a address in xml format.
        /// </summary>
        /// <param name="addressNode">XmlNode that represents an address in xml format.</param>
        /// <returns>Instance of address.</returns>
        private Address FormAddress(XmlNode addressNode)
        {
            Address address = new Address();
            address.Country = addressNode.ChildNodes[ConstantNames.NODE_ADDRESS_COUNTRY_INDEX]
                .FirstChild.Value;
            address.City = addressNode.ChildNodes[ConstantNames.NODE_ADDRESS_CITY_INDEX]
                .FirstChild.Value;
            address.Street = addressNode.ChildNodes[ConstantNames.NODE_ADDRESS_STREET_INDEX]
                .FirstChild.Value;
            return address;
        }
    }
}
