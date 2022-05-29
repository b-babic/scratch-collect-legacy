using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using scratch_collect.Desktop.Forms;
using scratch_collect.Desktop.Services;
using scratch_collect.Desktop.Utilities;
using System;
using System.Windows.Forms;

namespace scratch_collect.Desktop
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Define services
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));

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

            Application.Run(new Homepage());
        }
    }
}