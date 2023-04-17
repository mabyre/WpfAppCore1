using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WpfAppCore1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }

        private readonly MainWindow mainWindow;

        // Constructeur needed for partial class but never called
        public App()
        {
        }

        public App(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // AppSettings configuration file
            //
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            // -----------

            using IHost host = Host.CreateDefaultBuilder()
            .ConfigureLogging(builder =>
                builder.ClearProviders()
                    .AddColorConsoleLogger(configuration =>
                    {
                        // Replace warning value from appsettings.json of "Cyan"
                        configuration.LogLevelToColorMap[LogLevel.Warning] = ConsoleColor.DarkCyan;
                        // Replace warning value from appsettings.json of "Red"
                        configuration.LogLevelToColorMap[LogLevel.Error] = ConsoleColor.DarkRed;
                    }))
                    .Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation(3, "Here we are on OnStartup()"); // Logs in ConsoleColor.DarkGreen

            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
