﻿using System.IO;
using System.Windows;

using Microsoft.Extensions.Configuration;

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

            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
