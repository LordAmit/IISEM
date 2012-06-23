using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IISExpressManager
{
    internal static class IISEMSingleton
    {
        /*
        Written by lordamit
        lordamit {at] gmail [dot} com   
        */

        internal static bool InstanceAlreadyExists()
        {
            var processes = Process.GetProcessesByName("iisexpressmanager");
            if (processes.Length > 1) return true;
            return false;
        }
    }
}
