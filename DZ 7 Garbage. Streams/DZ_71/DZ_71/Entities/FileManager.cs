using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


//////////////////////////
//                      //
// It is only beginning //
//                      //
//////////////////////////


namespace geiko.DZ_71.Entities
{
    class FileManager : Interface.IFileManager
    {
        /// <summary>
        /// User menu
        /// </summary>
        public void FileManagerCarte()
        {
            Console.WriteLine("I am glad to see you!");
            Regex regex = new Regex(@"[^0-9]|[^1][^0-5]");   //   It is not 0 - 15

            string way="1";
            do
            {
                do
                {
                    Console.WriteLine("\n\nPlease, set: \n");
                    Console.WriteLine("0 - to exit");

                    Console.WriteLine("1 - to find files and folders by name;");
                    Console.WriteLine("2 - to find files and folders by size;");
                    Console.WriteLine("3 - to find files and folders by creation date;");
                    Console.WriteLine("4 - to find files and folders by access;");
                    Console.WriteLine("5 - to find files and folders by modification;");

                    Console.WriteLine("11 - to find text file by content;");

                    Console.WriteLine("12 - to delete string from found file");
                    Console.WriteLine("13 - to move string in found file");
                    Console.WriteLine("14 - to copy string in found file");
                    Console.WriteLine("15 - to replace current string with new string in found file");

                    way = Console.ReadLine();
                    Console.Clear();
                } while (regex.IsMatch(way));   

                Action(way);
            } while (way != "0");
            Console.WriteLine("Good by!");
            Console.ReadKey();
        }

        /// <summary>
        /// Implementation of user menu
        /// </summary>
        /// <param name="way"></param>
        void Action(string way)
        {
            List<FileSystemInfo> AttributeList = new List<FileSystemInfo>();
            AttributeList.Clear();
            string path;

            switch (way)
            {
                case "0": break;
                case "1":               //  осуществлять  поиск  файлов  и  папок  по  имени
                    Console.WriteLine("Enter Name of file/folder in order to find.");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter path to the disk or folder where to find.");
                    path = Console.ReadLine();

                    Find(path, name, AttributeList, NameComparator);
                    Console.ReadKey();
                    break;
                case "2":               //    осуществлять  поиск  файлов  и  папок  по  размеру
                    Console.WriteLine("Enter Size of file/folder in order to find all that are Longer.");
                    string size = Console.ReadLine();
                    Console.WriteLine("Enter path to the disk or folder where to find.");
                    path = Console.ReadLine();
                    
                    Find(path, size, AttributeList, SizeComparator);
                    Console.ReadKey();                    
                    break;
                case "3":               //    осуществлять  поиск  файлов  и  папок  по датам создания
                    Console.WriteLine("Enter Creation Date of file/folder in order to find all that are not Later.");
                    string date = Console.ReadLine();
                    Console.WriteLine("Enter path to the disk or folder where to find.");
                    path = Console.ReadLine();
                    
                    Find(path, date, AttributeList, DateComparator);
                    Console.ReadKey();                     
                    break;
                case "4":                //    осуществлять  поиск  файлов  и  папок  по  уровням доступа
                    Console.WriteLine("Enter Access of file/folder in order to find all that are Higher.");
                    string access = Console.ReadLine();
                    Console.WriteLine("Enter path to the disk or folder where to find.");
                    path = Console.ReadLine();
                    
                    
                    
                    break;
                case "5": break;
                case "6": break;
                case "7": break;
                case "8": break;
                case "9": break;
                case "10": break;
                default: Console.WriteLine("Default Error");
                        break;            
            }
        }



        /// <summary>
        /// Find file or directory in partiqular place with this path https://msdn.microsoft.com/ru-ru/library/system.io.filesysteminfo(v=vs.110).aspx
        /// </summary>
        /// <param name="path"> place where to find </param>
        /// <param name="param"> name or size or creation date or access or modification </param>
        /// <param name="comparator"></param>
        /// <param name="fsi"></param>
        static void Find(string path, string param, List<FileSystemInfo> AttributeList, Comparator comparator)
        {
            bool flag = false;
            foreach (string entry in Directory.GetDirectories(path))
            {
                FileSystemInfo ob = new DirectoryInfo(entry);
                if (ob == null) continue;
                if (comparator(ob, param))
                {
                    AttributeList.Add(ob);
                    flag = true;
                }

  //              Find(ob.FullName, param, AttributeList, comparator);
            }
            foreach (string entry in Directory.GetFiles(path))
            {
                FileSystemInfo ob = new DirectoryInfo(entry);
                if (comparator(ob, param))
                {
                   AttributeList.Add(ob);
                   flag = true;
                }
            }
            if (flag == false)
                Console.WriteLine("Found nothing.");

            foreach (FileSystemInfo elem in AttributeList)
            {
                DisplayFileSystemInfoAttributes(elem);
            }
        }

        /// <summary>
        /// Show attributies
        /// </summary>
        /// <param name="fsi"> object of FileSystemInfo </param>
        static void DisplayFileSystemInfoAttributes(FileSystemInfo fsi)
        {
            string entryType = "File";

            // Determine if entry is really a directory            
            if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                entryType = "Directory";
            }
            Console.WriteLine("{0} entry {1} was created on {2:D}", entryType, fsi.FullName, fsi.CreationTime);
        }

        /// <summary>
        /// DELEGATE
        /// </summary>
        /// <param name="fsi">FileSystemInfo object - Attributes of file or directory</param>
        /// <param name="param">parameter for comparison</param>
        /// <returns></returns>
        public delegate bool Comparator(FileSystemInfo current, string param);       ///////////////////////////////


        public bool NameComparator(FileSystemInfo current, string name)
        {
            return string.Equals(current.Name, name);
        }


        public bool SizeComparator(FileSystemInfo current, string size)
        {
            long length;
            if ((current.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo di = new DirectoryInfo(current.FullName);
                length = DirSize(di);
            }
            else
                length = new System.IO.FileInfo(current.FullName).Length;

            long Size;
            bool res = long.TryParse(size, out Size);  
            if (res == false)
                throw new ArgumentOutOfRangeException("SIZE is not correct");
            else
                return (length > Size);
        }

        public static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }


        public bool DateComparator(FileSystemInfo current, string date)
        {
            DateTime Date = Convert.ToDateTime(date);
            int temp = DateTime.Compare(current.CreationTime.Date, Date.Date);
            return (temp >= 0);
        }
    }
}

