using System;

namespace geiko.exam
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string manifestAddress = @".\main.manifest.txt";
                UserMenu um = new UserMenu(manifestAddress);
                um.ShowGeographyInfo();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("By!");
                Console.ReadKey();
            }
        }
    }
}
