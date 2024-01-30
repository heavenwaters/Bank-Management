using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerBankAccountManagementSystem
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
            try
            {
                Application.Run(new Form6());
                Application.Run(new Form2());
            }
            catch
            {
                MessageBox.Show("Sorry there was an error! Restart the program");
                Application.Exit();
            }

        }
    }
}
