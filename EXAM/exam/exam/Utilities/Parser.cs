using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using geiko.exam.Entities;

namespace geiko.exam.Utilities
{
    /// <summary>
    /// This class allows to parse manifest and create instansies of entity classes;
    /// </summary>
    class Parser : IParser
    {
        /// <summary>
        /// This method allows to read a manifest file.
        /// </summary>
        /// <param name="manifestPath">path to file of manifest</param>
        /// <param name="countries">list of country instancies</param>
        /// <param name="um">instance of user menu</param>
        public void parse(string manifestPath, List<Country> countries, UserMenu um)
        {
            StreamReader reader = null;
            try
            {
                using (reader = new StreamReader(manifestPath, Encoding.GetEncoding(1251)))
                {
                    read(reader, countries, um);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        /// <summary>
        /// THis method reads a manifest and directs info to entity class instancies.
        /// </summary>
        /// <param name="reader">instance of StreamReader</param>
        /// <param name="countries">List of countries</param>
        /// <param name="um">instance of user menu</param>
        private void read(StreamReader reader, List<Country> countries, UserMenu um)
        {            
            Regex regexComment = new Regex(@"^#");
            Regex regexDir = new Regex(@"^default_directory=");
            Regex regexEdit = new Regex(@"^editor=");
            Regex regexCountries = new Regex(@"^countries {");
            Regex regexBlockEnd = new Regex(@"^}");
            Regex regexDomain = new Regex(@"^distincts {");
            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (regexComment.IsMatch(line))
                        continue;

                    else if (regexDir.IsMatch(line))
                        um.startPath = Path.Combine(line.Substring(18), "countries");

                    else if (regexEdit.IsMatch(line))
                        um.editor = line.Substring(7, 11);

                    else if (regexCountries.IsMatch(line))
                        findCountries(reader, regexBlockEnd, countries, um.startPath);

                    else if (regexDomain.IsMatch(line))
                        findDomainName(reader, regexBlockEnd, countries);

                    else if (countries.Count > 0)
                        findDomainInCountries(reader, regexBlockEnd, countries, line, um.startPath);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        /// <summary>
        /// This method retrieves country info, creates country objects and adds them to the List of countries.
        /// </summary>
        /// <param name="reader">instance of StreamReader class</param>
        /// <param name="regexBlockEnd">regex for end of block</param>
        /// <param name="countries">list of countries</param>
        /// <param name="startPath">path to countries folders</param>
        private void findCountries(StreamReader reader, Regex regexBlockEnd, List<Country> countries, string startPath)
        {
            string str = string.Empty;
            while (true)
            {
                try
                {
                    str = reader.ReadLine();
                    if (regexBlockEnd.IsMatch(str))
                        break;
                    str = str.Trim();
                    string[] split = str.Split(new char[] { '=' });
                    countries.Add(new Country(split[0], split[1], "", Path.Combine(startPath, split[1])));
                }
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }           
        }

        /// <summary>
        /// This method retrieves domainName of the country and assignes filds of country instances.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="regexBlockEnd"></param>
        /// <param name="countries"></param>
        private void findDomainName(StreamReader reader, Regex regexBlockEnd, List<Country> countries)
        {
            string str = string.Empty;
            while (true)
            {
                try
                {
                    str = reader.ReadLine();
                    if (regexBlockEnd.IsMatch(str))
                        break;
                    str = str.Trim();
                    string[] split = str.Split(new char[] { '=' });

                    foreach (Country country in countries)
                    {
                        if (country.FolderName == split[0])
                            country.DomainUnitName = split[1];
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// This method retrieves domain info, creates domain objects and adds them to the List of domains.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="regexBlockEnd"></param>
        /// <param name="countries"></param>
        /// <param name="line"></param>
        /// <param name="startPath"></param>
        private void findDomainInCountries(StreamReader reader, Regex regexBlockEnd, List<Country> countries, string line, string startPath)
        {
            foreach (Country country in countries)
            {
                try
                {
                    string countryPath = Path.Combine(startPath, country.FolderName);
                    Regex regexThisCountry = new Regex(@"^" + country.FolderName + " {");
                    if (regexThisCountry.IsMatch(line))
                    {
                        string str = string.Empty;
                        while (true)
                        {
                            str = reader.ReadLine();
                            if (regexBlockEnd.IsMatch(str))
                                break;
                            str = str.Trim();
                            string[] split = str.Split(new char[] { '=' });

                            country.domains.Add(new Domain(split[0], split[1], Path.Combine(countryPath, split[1])));
                        }
                    }
                    if (country.domains.Count > 0)
                        findCityInDomain(reader, regexBlockEnd, country.domains, line, countryPath);
                }
                catch ( SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        /// <summary>
        /// This method retrieves city info and creats city structure. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="regexBlockEnd"></param>
        /// <param name="domains"></param>
        /// <param name="line"></param>
        /// <param name="countryPath"></param>
        private void findCityInDomain(StreamReader reader, Regex regexBlockEnd, List<Domain> domains, string line, string countryPath)
        {
            foreach (Domain domain in domains)
            {
                try
                {
                    Regex regexThisDomain = new Regex("^" + domain.FolderName + " {");
                    if (regexThisDomain.IsMatch(line))
                    {
                        string str = string.Empty;
                        while (true)
                        {
                            str = reader.ReadLine();
                            if (regexBlockEnd.IsMatch(str))
                                break;
                            str = str.Trim();
                            string[] split = str.Split(new char[] { '=' });

                            string fullPath = Path.Combine(countryPath, domain.FolderName, split[1]);

                            City city;
                            city.name = split[0];
                            city.fileName = split[1];
                            city.PathToFile = fullPath;
                            domain.cities.Add(city);
                        }
                    }
                }
                catch(SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
