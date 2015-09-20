using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.exam.Entities
{
    /// <summary>
    /// This class represents a country.
    /// </summary>
    class Country
    {
        /// <summary>
        /// This property admits to get and to set a name of the country. 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This property admits to get and to set a nickname or folder name of this country.
        /// </summary>
        public string FolderName { get; set; }
        /// <summary>
        /// This property admits to get and to set a name of domain unit in this country.
        /// </summary>
        public string DomainUnitName { get; set; }
        /// <summary>
        /// This property admits to get and to set a path to the folder of this country.
        /// </summary>
        public string PathToCountry { get; set; }
        /// <summary>
        /// This List contains object of domains of this country.
        /// </summary>
        public List<Domain> domains;
        /// <summary>
        /// This is constructor of country instances.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="folderName"></param>
        /// <param name="domainName"></param>
        /// <param name="pathToCountry"></param>
        public Country(string name, string folderName, string domainName, string pathToCountry)
        {
            this.domains = new List<Domain>();
            this.Name = name;
            this.FolderName = folderName;
            this.DomainUnitName = domainName;
            this.PathToCountry = pathToCountry;
        }
    }
}
