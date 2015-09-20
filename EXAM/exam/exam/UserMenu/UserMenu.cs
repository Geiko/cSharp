using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using geiko.exam.Entities;
using System.IO;

namespace geiko.exam
{
    /// <summary>
    /// This class represents a menu for users.
    /// </summary>
    class UserMenu : IUserMenu
    {
        /// <summary>
        /// This fild keeps a value of manifest address.
        /// </summary>
        public string manifestAddress;
        /// <summary>
        /// This fild keeps a value of path to country folders. 
        /// </summary>
        public string startPath;
        /// <summary>
        /// THis fild keeps a name of editor;
        /// </summary>
        public string editor;
        /// <summary>
        /// This List contains objects of countries.
        /// </summary>
        public List<Country> countries;
        /// <summary>
        /// This is constructor of user menu instance.
        /// </summary>
        /// <param name="manifestAddress">address of manifest</param>
        public UserMenu(String manifestAddress)
        {
            this.manifestAddress = manifestAddress;
            this.startPath = string.Empty;
            this.editor = "notepad.exe";
            this.countries = new List<Country>();
        }


        /// <summary>
        /// This method allows a user to choose country, domain, city
        /// and create them
        /// and to edit info city file.
        /// It shoudbe be used a recursion next time.
        /// </summary>
        public void ShowGeographyInfo()
        {
            if (!File.Exists(manifestAddress))
                Console.WriteLine("Manifest address is not correct.");
            else
            {
                Utilities.Parser parser = new Utilities.Parser();
                parser.parse(manifestAddress, countries, this);
                Utilities.FileServis fileServis = new Utilities.FileServis();

                while (true)
                {
                    int domainNumber;
                    int cityNumber = -1;

                    int countryNumber = chooseCountry();
                    if (countryNumber == 0)
                        return;

                    if (countryNumber == 1)
                        fileServis.createCountry(this);
                    else if (countryNumber > 1)
                    {
                        domainNumber = chooseDomain(countries[countryNumber - 2]);
                        if (domainNumber == 0)
                            continue;
                        else if (domainNumber == 1)
                            fileServis.createDomain(countries[countryNumber - 2], this);
                        else if (domainNumber > 1)
                        {
                            cityNumber = chooseCity(countries[countryNumber - 2].domains[domainNumber - 2]);
                            if (cityNumber == 0)
                                continue;
                            else if (cityNumber == 1)
                                fileServis.createFile(countries[countryNumber - 2].domains[domainNumber - 2], this);
                            else if (cityNumber > 1)
                            {
                                string thePath = countries[countryNumber - 2].domains[domainNumber - 2].cities[cityNumber - 2].PathToFile;
                                actWithCities(thePath, editor, fileServis);
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// This method allows to choose a country.
        /// </summary>
        /// <returns></returns>
        private int chooseCountry()
        {
            int ch;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please, select a country:\n\n 0 - to quit\n 1 - to create new country\n");
                int k = 1;
                if (countries.Count == 0)
                    Console.WriteLine("There is no country in the data base.");
                else
                {
                    foreach (Country country in countries)
                    {
                        k++;
                        Console.WriteLine(" {0} - {1}", k, country.Name);
                    }
                }
                string chois = Console.ReadLine();
                if (int.TryParse(chois, out ch))
                {
                    if (ch >= 0 && ch <= k)
                        break;
                }
            }
            return ch;
        }


        /// <summary>
        /// This method allows to choose a domain.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private int chooseDomain(Country country)
        {
            int ch;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please, select a {0}:\n\n 0 - to return in main menu\n 1 - to create a new {0}\n", country.DomainUnitName);
                int k = 1;
                if (country.domains.Count == 0)
                    Console.WriteLine("There is no {0} in this country.", country.DomainUnitName);
                else
                {
                    foreach (Domain domain in country.domains)
                    {
                        k++;
                        Console.WriteLine(" {0} - {1}", k, domain.Name);
                    }
                }
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out ch))
                {
                    if (ch >= 0 && ch <= k)
                        break;
                }
            }
            return ch;
        }


        /// <summary>
        /// This method allows to choose a city.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        private int chooseCity(Domain domain)
        {
            int ch;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please, select a city:\n\n 0 - to return in main menu\n 1 - to create a new city info file\n");
                int k = 1;
                if (domain.cities.Count == 0)
                    Console.WriteLine("There is no city in this domain.");
                else
                {
                    foreach (City city in domain.cities)
                    {
                        k++;
                        Console.WriteLine(" {0} - {1}", k, city.name);
                    }
                }
                string chois = Console.ReadLine();
                if (int.TryParse(chois, out ch))
                {
                    if (ch >= 0 && ch <= k)
                        break;
                }
            }
            return ch;
        }


        /// <summary>
        /// This method directs a user choice.
        /// </summary>
        /// <param name="thePath">this is path to the file of chosen city</param>
        /// <param name="editor">name of editor</param>
        /// <param name="fileServis">class of file servis</param>
        private void actWithCities(string thePath, string editor, Utilities.FileServis fileServis)
        {
            int actionNumber = chooseAction();
            switch (actionNumber)
            {
                case 0:
                    return;
                case 1:
                    showCityInfo(thePath);
                    break;
                case 2:
                    fileServis.writeCommandToManifest(thePath, this);
                    System.Diagnostics.Process.Start(editor, thePath);
                    break;
            }
        }


        /// <summary>
        /// This method allows to choose an action with a city - reading, editing or quiting.
        /// It is also verifies and admits only correct choise.
        /// </summary>
        /// <returns>it returns a number of choose</returns>
        private int chooseAction()
        {
            int ch;
            while (true)
            {
                Console.WriteLine("What would you like to do with this file? Select, please:");
                Console.WriteLine(" 0 - to quit\n 1 - to read\n 2 - to edit");
                string chois = Console.ReadLine();
                if (int.TryParse(chois, out ch))
                {
                    if (ch >= 0 && ch <= 3)
                        break;
                }
            }
            return ch;
        }


        /// <summary>
        /// This method allows to read info about the city, it opens the file in console.
        /// </summary>
        /// <param name="fullPathToFile">path to the city file</param>
        private void showCityInfo(string fullPathToFile)
        {
            StreamReader reader = null;
            try
            {
                using (reader = new StreamReader(fullPathToFile, Encoding.GetEncoding(1251)))
                {
                    Console.Clear();
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }



    }
}
