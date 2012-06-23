using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;

namespace IISExpressManager
{
    internal class ProcessCommandLineFinder
    {
        /*
            Written by lordamit
            lordamit {at] gmail [dot} com
        */
        private static List<string> _commandLines = new List<string>();

        internal static string FindProcessStartCommandLineByProcessId(int processId)
        {
            _commandLines = null;
            _commandLines = new List<string>();
            try
            {
                using (
                    var searcher =
                        new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " +
                                                     processId))
                {
                    foreach (ManagementObject @object in searcher.Get())
                    {
                        _commandLines.Add(@object["CommandLine"] + " ");
                    }
                }
            }
            catch (Win32Exception ex)
            {
                if ((uint) ex.ErrorCode != 0x80004005)
                {
                    throw;
                }
            }
            return _commandLines[0];
        }

        internal static List<string> FindAllProcessStartCommandLineByProcessName(string processname)
        {
            foreach (Process p in Process.GetProcessesByName(processname))
            {
                try
                {
                    using (
                        var searcher =
                            new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " +
                                                         p.Id))
                    {
                        foreach (ManagementObject @object in searcher.Get())
                        {
                            _commandLines.Add(@object["CommandLine"] + " ");
                        }
                    }
                }
                catch (Win32Exception ex)
                {
                    if ((uint) ex.ErrorCode != 0x80004005)
                    {
                        throw;
                    }
                }
            }
            return _commandLines;
        }
    }
}