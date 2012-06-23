using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using IISExpressManager;

namespace TestConsole
{
    class Program
    {
        private static string FindSiteName(string listItem)
        {
            int indexOfSite = listItem.IndexOf("site:\"");
            string temp = listItem.Substring(indexOfSite+6);
            int indexOfsecondQuoteAroundSiteName = temp.IndexOf("\"");
            return temp.Substring(0,indexOfsecondQuoteAroundSiteName);
        }

        static void Main(string[] args)
        {
            var processes = Process.GetProcessesByName("iisexpressmanager");
            foreach (var process in processes)
            {
                Console.WriteLine(process.Id);
            }
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }
    }
}
