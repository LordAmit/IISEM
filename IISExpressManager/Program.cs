using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace IISExpressManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (IISEMSingleton.InstanceAlreadyExists())
            {
                MessageBox.Show(
                    "You can only have one instance of IISEM running.",
                    "Warning!",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            Application.Run(new Form1());
        }

    }
}
