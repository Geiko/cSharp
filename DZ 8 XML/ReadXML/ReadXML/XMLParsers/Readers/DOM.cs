using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadXML
{
    /// <summary>
    /// IXmlReader implementation using DOM API
    /// </summary>
    class DOMReader: IXmlReader
    {
        /// <summary>
        /// Reads xml file from disk and returns it in string format
        /// </summary>
        /// <param name="filePath">Path to xml file</param>
        /// <returns>Xml in string form</returns>
        /// <exception cref="System.IO.FileNotFoundException">When file can not be opened</exception>
        public string readXml(string filePath)
        {
            //1. Создаем XmlDocument
            XmlDocument doc = new XmlDocument();
            //2. Загружаем файл документа в ОЗУ
            doc.Load(filePath);
            //3. Получаем корневой элемент
            XmlElement root = doc.DocumentElement;
            StringBuilder builder = new StringBuilder();
            ParseElement(builder, root);
            return builder.ToString();
        }

        /// <summary>
        /// Recursive traversal of document tree and recording of node info into a string.
        /// </summary>
        /// <param name="builder">A string builder.</param>
        /// <param name="element">A document node.</param>
        private void ParseElement(StringBuilder builder, XmlNode element)
        {
            builder.Append(string.Format("Name = {0}\tValue = {1}\tType = {2}\n", element.Name, element.Value, element.NodeType));
            XmlAttributeCollection attributes = element.Attributes;
            if (attributes != null)
            {
                foreach (XmlAttribute attr in attributes)
                {
                    builder.Append(string.Format("Attribute: name = {0}\tvalue = {1}\n", attr.Name, attr.Value));
                }
            }
            var children = element.ChildNodes;
            
            foreach (XmlNode child in children)
            {
                ParseElement(builder, child);
            }
        }
    }
}
