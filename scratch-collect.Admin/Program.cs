using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using scratch_collect.Admin.Forms;
using scratch_collect.Admin.Utilities;
using System;
using System.Windows.Forms;

namespace scratch_collect.Admin
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();

            // TODO: Remove before MVP
            Application.Run(new MainForm());
        }
    }
}