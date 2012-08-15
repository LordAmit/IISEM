using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IISExpressManager
{
    using System.ComponentModel;
    using System.Windows.Forms;

    internal class IISProcessManager
    {
        /*
            Written by lordamit
         *  lordamit {at] gmail [dot} com
        */
        private static List<IISSites> MapSiteNameWithProcessId(List<IISSites> iisSites, string processId, string siteName)
        {
            foreach (var iisSite in iisSites)
            {
                if (iisSite.SiteName.Equals(siteName))
                {
                    iisSite.Status = "Started";
                    iisSite.ProcessId = processId;
                }
            }
            return iisSites;
        }

        internal static List<IISSites> AssignProcessIds(List<IISSites> iisSites)
        {
            var onGoingIISProcesses = Process.GetProcessesByName("iisexpress");
            foreach (var process in onGoingIISProcesses)
            {
                string commandLine = ProcessCommandLineFinder.FindProcessStartCommandLineByProcessId(process.Id);
                if (commandLine.Contains("/site:\""))
                {
                    string siteName = FindSiteName(commandLine);
                    iisSites = MapSiteNameWithProcessId(iisSites, process.Id.ToString(), siteName);
                }
            }
            return iisSites;
        }

        internal static void ExecuteProcess(string pathOfExe, string arguments)
        {
            var p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = pathOfExe;
            p.StartInfo.Arguments = arguments;
            try
            {
                p.Start();
            }
            catch (Win32Exception ex)
            {
                string fileName = DateTime.Now.ToString("dd_MM_yy-hh-mm-ss") + ".txt";
                MessageBox.Show("Severe Error. It looks like your IISExpress is corrupted.\nPlease reinstall IISExpress"
                    //+ "\nA logfile has been saved to your IISEM directory." 
                                + "\nIISEM will close now.",
                                "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                /*
                 * removed this part. No significant details can be found from the thrown exception.
                //File.WriteAllText(fileName, ex.Message);
                //File.AppendAllText(fileName, ex.StackTrace);
                //File.AppendAllText(fileName,ex.NativeErrorCode.ToString());*/
                throw;
            }
            p.Dispose();
            p.Close();
            
        }

        private static string FindSiteName(string listItem)
        {
            int indexOfSite = listItem.IndexOf("site:\"", System.StringComparison.Ordinal);
            string temp = listItem.Substring(indexOfSite + 6);
            int indexOfsecondQuoteAroundSiteName = temp.IndexOf("\"", System.StringComparison.Ordinal);
            return temp.Substring(0, indexOfsecondQuoteAroundSiteName);
        }

        internal static void FindWebsite()
        {
            List<string> list = ProcessCommandLineFinder.FindAllProcessStartCommandLineByProcessName("iisexpress");

            foreach (string listItem in list)
            {
                if (listItem.Contains("/site:\""))
                {
                    FindSiteName(listItem);
                }
                else if (listItem.Contains("/siteId:"))
                {
                    Console.WriteLine("type2: " + listItem);
                }
            }
        }

        internal static void KillAllhostedApplications()
        {
            var p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "taskkill";
            foreach (Process process in Process.GetProcessesByName("iisexpress"))
            {
                p.StartInfo.Arguments = "/pid " + process.Id;
                p.Start();
            }
            p.Close();
        }
    }
}