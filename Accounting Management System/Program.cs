using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_Management_System
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
            Application.Run(new Form1());
            if(System.Windows.Forms.Application.MessageLoop)
            {
              // Use this since we are a WinForms app
                System.Windows.Forms.Application.Exit();
            }
             else
            {
              // Use this since we are a console app
              System.Environment.Exit(1);
            }
        }
    }
}
