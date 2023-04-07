﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppCore1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
