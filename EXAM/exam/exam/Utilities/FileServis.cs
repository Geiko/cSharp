using geiko.exam.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace geiko.exam.Utilities
{
    /// <summary>
    /// This class provides working with files and directories.
    /// </summary>
    class FileServis : IFileServis
    {            
        /// <summary>
        /// This method creates a new file of city info and inserts the info to the manifest.
        /// </summary>
        /// <param name="domain">instance of a domain</param>
        /// <param name="um">instance of user menu</param>
        public void createFile(exam.Entities.Domain domain, UserMenu um)  
        {
            Console.WriteLine("Enter city name:");
            string cityName = Console.ReadLine();
            Console.WriteLine("Enter city nickname:");
            string fileName = Console.ReadLine() + ".txt";
            try
            {
                StreamWriter writer = new StreamWriter(Path.Combine(domain.PathToDomain, fileName), true, Encoding.GetEncoding(1251));
                City city;
                city.name = cityName;
                city.fileName = fileName;
                city.PathToFile = Path.Combine(domain.PathToDomain, fileName);
                domain.cities.Add(city);

                Regex regexDomain = new Regex(@"^" + domain.FolderName + " {");
                insertItemInManifest(um, regexDomain, cityName, fileName);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// This method inserts an item of block to the manifest.
        /// </summary>
        /// <param name="um">instance of a user menu</param>
        /// <param name="regex">instance of a regex class</param>
        /// <param name="name">a name</param>
        /// <param name="nickname">a nickname or name of folder</param>
        private void insertItemInManifest(UserMenu um, Regex regex, string name, string nickname)
        {
            StringBuilder sBilder = new StringBuilder();
            using (StreamReader reader = new StreamReader(um.manifestAddress, Encoding.GetEncoding(1251)))
            {
                string lineFromManifest;
                do
                {
                    lineFromManifest = reader.ReadLine();
                    sBilder.AppendLine(lineFromManifest);
                } while (!regex.IsMatch(lineFromManifest));

                sBilder.Append("\t" + name + "=" + nickname + "\n");
                sBilder.Append(reader.ReadToEnd());
            }
            using (StreamWriter sr = new StreamWriter(um.manifestAddress, false, Encoding.GetEncoding(1251)))
            {
                sr.Write(sBilder.ToString());
            }
        }


        /// <summary>
        /// This method creates a new folder of domain and adds domain info to the manifest.
        /// </summary>
        /// <param name="country">instance of country</param>
        /// <param name="um">instance of user menu</param>
        public void createDomain(exam.Entities.Country country, UserMenu um)
        {
            Console.WriteLine("Enter {0} name:", country.DomainUnitName);
            string domainName = Console.ReadLine();
            Console.WriteLine("Enter {0} nickname:", country.DomainUnitName);
            string domainNickname = Console.ReadLine();
            string pathToNewDomain = Path.Combine(country.PathToCountry, domainNickname);
            try
            {
                if (Directory.Exists(pathToNewDomain))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathToNewDomain);
                country.domains.Add(new Domain(domainName, domainNickname, Path.Combine(country.PathToCountry, domainNickname)));

                Regex regexCountry = new Regex(@"^" + country.FolderName + " {");
                insertItemInManifest(um, regexCountry, domainName, domainNickname);

                insertDomainBlockToManifest(um, country, domainNickname);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        /// <summary>
        /// This method inserts domain block to manifes.
        /// </summary>
        /// <param name="um">instance of user menu</param>
        /// <param name="country">instance of country</param>
        /// <param name="domainNickname">domain nickname or folder name of domain</param>
        private void insertDomainBlockToManifest(UserMenu um, Entities.Country country, string domainNickname)
        {
            Regex regex1 = new Regex(@"^" + country.FolderName + " {");
            StringBuilder sBilder = new StringBuilder();
            using (StreamReader reader = new StreamReader(um.manifestAddress, Encoding.GetEncoding(1251)))
            {
                string lineFromManifest;
                do
                {
                    lineFromManifest = reader.ReadLine();
                    sBilder.AppendLine(lineFromManifest);
                } while (!regex1.IsMatch(lineFromManifest));

                Regex regex2 = new Regex(@"^}");
                do
                {
                    lineFromManifest = reader.ReadLine();
                    sBilder.AppendLine(lineFromManifest);
                } while (!regex2.IsMatch(lineFromManifest));

                sBilder.Append(domainNickname + " {\n}\n");
                sBilder.Append(reader.ReadToEnd());
            }
            using (StreamWriter sr = new StreamWriter(um.manifestAddress, false, Encoding.GetEncoding(1251)))
            {
                sr.Write(sBilder.ToString());
            }           
        }

        /// <summary>
        /// This method creates a new folder of country and adds country info to the manifest.
        /// </summary>
        /// <param name="um">instance of user menu</param>
        public void createCountry(UserMenu um)
        {
            Console.WriteLine("Enter country name:");
            string countryName = Console.ReadLine();
            Console.WriteLine("Enter country nickname:");
            string countryNickname = Console.ReadLine();
            Console.WriteLine("Enter distincts name for this country.");
            string distinctName = Console.ReadLine();
            string pathToNewCountry = Path.Combine(um.startPath, countryNickname);
            try
            {
                if (Directory.Exists(pathToNewCountry))
                {
                    Console.WriteLine("That path exists already. Press any key.");
                    Console.ReadKey();
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathToNewCountry);
                um.countries.Add(new Country(countryName, countryNickname, distinctName, Path.Combine(um.startPath, countryNickname)));
                
                Regex regexCountries = new Regex(@"^countries {");
                insertItemInManifest(um, regexCountries, countryName, countryNickname);

                Regex regexDist = new Regex(@"^distincts {");
                insertItemInManifest(um, regexDist, countryNickname, distinctName);

                Console.WriteLine("Enter folder name for this country.");
                string foldName = Console.ReadLine();
                Regex regexFold = new Regex(@"^folders {");
                insertItemInManifest(um, regexFold, countryNickname, foldName);

                insertCountryBlockInManifest(um, countryNickname, countryName);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// This method inserts block of country to manifest.
        /// </summary>
        /// <param name="um"></param>
        /// <param name="countryNickname"></param>
        /// <param name="countryName"></param>
        private void insertCountryBlockInManifest(UserMenu um, string countryNickname, string countryName)
        {
            string countryBlock = "\n#описание " + countryName + "\n"  + countryNickname + " {\n}\n";
            try
            {
                using (StreamWriter writer = new StreamWriter(um.manifestAddress, true, Encoding.GetEncoding(1251)))
                {
                    writer.Write(countryBlock);
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }


        }


        /// <summary>
        /// This method inserts command of opening editor with loaded file to manifest.
        /// </summary>
        /// <param name="thePath">path to file</param>
        /// <param name="um">instance of user menu</param>
        public void writeCommandToManifest(string thePath, UserMenu um)
        {
            try
            {
                StringBuilder sBilder = new StringBuilder();
                using (StreamReader reader = new StreamReader(um.manifestAddress, Encoding.GetEncoding(1251)))
                {
                    string lineFromManifest;
                    Regex regexEditor = new Regex(@"^editor=");
                    while (true)
                    {
                        lineFromManifest = reader.ReadLine();
                        if (regexEditor.IsMatch(lineFromManifest))
                            break;
                        sBilder.AppendLine(lineFromManifest);
                    }
                    Regex regexPath = new Regex(@" .*");
                    string command = regexPath.Replace(lineFromManifest, " " + thePath);

                    sBilder.AppendLine(command);
                    sBilder.Append(reader.ReadToEnd());
                }
                using (StreamWriter sr = new StreamWriter(um.manifestAddress, false, Encoding.GetEncoding(1251)))
                {
                    sr.Write(sBilder.ToString());
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }




    }
}
