using scratch_collect.Admin.Forms;
using System;
using System.Windows.Forms;

namespace scratch_collect.Admin
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // TODO: Remove before MVP
            Application.Run(new MainForm());
        }
    }
}