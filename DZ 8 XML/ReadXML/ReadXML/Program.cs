//Дописать этот проект. А именно:
//1) вынести все имена и индексы элементов в отдельный статический класс;
//2) дописать сохранение студента в XML в классе DOMStudentXMLWriter;
//3) написать реализацию интерфейса IStudentXMLReader при помощи XmlTextReader (см. урок 8);
//4) реализовать валидацию xml файла по схеме перед чтением (см. урок 8);
//5) написать необходимые комментарии (///)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;


namespace ReadXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //IXmlReader reader = new DOMReader();
            //Console.WriteLine(reader.readXml("files\\students.xml"));
            //Console.ReadKey();

            //IStudentXMLReader studentReader = new DOMStudentReader();
            //ICollection<Student> students = studentReader.ReadAll("files\\students.xml");
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student);
            //}

            IStudentXMLWriter writer = new DOMStudentXMLWriter();
            writer.WriteAll
            (
                new Student[] 
                {
                    new Student 
                    { 
                        Login = "log", 
                        Faculty = "fac",
                        Name = "Natasha",
                        Phone = "324587",
                        Address = new Address 
                        {
                            Country = "UA",
                            City = "DP",
                            Street = "KM"
                        }
                    },

                    new Student
                    {
                        Login = "log2", 
                        Faculty = "fac2",
                        Name = "Lola",
                        Phone = "98765",
                        Address = new Address 
                        {
                            Country = "USA",
                            City = "SD",
                            Street = "SP"
                        }
                    }

                }, "files\\newStudents.xml"
            );
            
            // It is Validation of xml file with Schema
            if (args.Length < 2)
            {
                Console.WriteLine("Syntax; VALIDATE xmldoc schemadoc");
                Console.ReadKey();
                return;
            } 
            ValidateXMLFile(args[0], args[1]);

            // It is reading of xml file with XmlTextReader
            IStudentXMLReader textReader = new DOMStudentXmlTextReader();
            ICollection<Student> students = textReader.ReadAll(args[0]);
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.ReadKey();
        }


        /// <summary>
        /// Validates of xml file with Schema.
        /// </summary>
        /// <param name="arg0">args[0] - argument of cmd</param>
        /// <param name="arg1">args[1] - argument of cmd</param>
        private static void ValidateXMLFile(string arg0, string arg1)
        {
            XmlValidatingReader validateReader = null;
            XmlTextReader nvr = null;
            try
            {
                nvr = new XmlTextReader(arg0);
                nvr.WhitespaceHandling = WhitespaceHandling.None;

                validateReader = new XmlValidatingReader(nvr);
                validateReader.Schemas.Add(GetTargetNamespace(arg1), arg1);
                validateReader.ValidationEventHandler += new ValidationEventHandler(OnValidationError);
                while (validateReader.Read()) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                if (validateReader != null)
                    validateReader.Close();
            }
        }

        /// <summary>
        /// It is a delegate or handler function.
        /// </summary>
        /// <param name="sender">Publisher.</param>
        /// <param name="e">Exception message.</param>
        static void OnValidationError(object sender, ValidationEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        /// <summary>
        /// Determines target namespace with XmlTextReader
        /// </summary>
        /// <param name="src">Schema document or xsd file or args[1].</param>
        /// <returns>String of namespace.</returns>
        public static string GetTargetNamespace(string src) 
        { 
            XmlTextReader reader = null; 
            try 
            { 
                reader = new XmlTextReader (src); 
                reader.WhitespaceHandling = WhitespaceHandling.None; 
                while (reader.Read()) 
                { 
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "schema") 
                    { 
                        while (reader.MoveToNextAttribute ()) 
                        { 
                            if (reader.Name == "targetNamespace") 
                                return reader.Value; 
                        } 
                    } 
                } 
                return ""; 
            }  
            finally  
            { 
                if (reader != null) 
                    reader.Close () ; 
            } 
        } 
    }
}
