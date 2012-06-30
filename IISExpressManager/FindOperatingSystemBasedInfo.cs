using System;

namespace IISExpressManager
{
    /*
     Written by lordamit
     lordamit {at] gmail [dot} com   
    */

    internal class FindOperatingSystemBasedInfo
    {
        
        internal static string OperatingSystemSpecificIISLocation()
        {
            //Used to Find Integer Pointer Size. Size 8 = 64 bit, size 4 = 32 bit OS
            int size = IntPtr.Size;

            if (size == 8) return @"C:\Program Files (x86)\IIS Express\iisexpress.exe";
            if (size == 4) return @"C:\Program Files\IIS Express\iisexpress.exe";

            return "null";
        }
    }
}