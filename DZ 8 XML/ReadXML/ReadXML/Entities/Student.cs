using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXML
{
    /// <summary>
    /// Represents a student from the academy
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student's login, must be unique.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Student's faculty.
        /// </summary>
        public string Faculty { get; set; }
        
        /// <summary>
        /// Student's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Student's phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Student's address
        /// </summary>
        public Address Address { get; set; }

        public override string ToString()
        {
            return string.Format
            (
                "{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n-----------\n",
                this.Login, 
                this.Faculty, 
                this.Name, 
                this.Phone, 
                this.Address.Country,
                this.Address.City, 
                this.Address.Street
            );
        } 
    }
}
