using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.exam.Entities
{
    /// <summary>
    /// This class represents a domain.
    /// </summary>
    class Domain
    {
        /// <summary>
        /// This property admits to get and to set a name of this domain.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This property admits to get and to set a nickname or a folder name of this domain.
        /// </summary>
        public string FolderName { get; set; }
        /// <summary>
        /// This property admits to get and to set a path to this domain.
        /// </summary>
        public string PathToDomain { get; set; }
        /// <summary>
        /// This List contains objects of cities of this domain.
        /// </summary>
        public List<City> cities;
        /// <summary>
        /// This is a constructor of domain instances.
        /// </summary>
        /// <param name="name">domain name</param>
        /// <param name="folderName">domain folder name</param>
        /// <param name="pathToDomain">path to domain</param>
        public Domain(string name, string folderName, string pathToDomain)
        {
            this.Name = name;
            this.FolderName = folderName;
            this.PathToDomain = pathToDomain;
            this.cities = new List<City>();
        }
    }
}
