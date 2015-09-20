/*
1.  Написать консольное приложение, реализующее работу с файлами. 
 
    Приложение должно удовлетворять следующим требованиям: 
 
    1) наличие меню; 
 
    2) возможность  осуществлять  поиск  файлов  и  папок  по  имени, размеру, датам создания, доступа и модификации; 
  
    3) осуществлять поиск текстовых файлов по содержимому;  
 
    4) работа с найденным списком – удаление, перемещение, копирование,  замена  в  выбранных  текстовых  файлах  одной  подстроки на другую.
 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.DZ_71
{
    class Program
    {
        static void Main(string[] args)
        {
            Entities.FileManager fileManager = new Entities.FileManager();
            try
            {
                fileManager.FileManagerCarte();
            }
            catch (SystemException e)
            {
                Console.WriteLine("\n I've caught a System Exception: {0}", e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
