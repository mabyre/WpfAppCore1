// 
// Sample Log with ASP.NET Core Logging
// https://github.com/aspnet/Logging
//
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppCore1
{
    /// <summary>
    /// Logique d'interaction pour UserControlLog.xaml
    /// </summary>
    public partial class UserControlLog : UserControl
    {
        private ILogger<UserControlLog> logger;

        public UserControlLog(ILoggerFactory loggerFactory)
        {
            InitializeComponent();
            
            // In xaml there is some text in Text so add a NexLine
            textBoxLog.Text += Environment.NewLine;

            logger = loggerFactory.CreateLogger<UserControlLog>();
            logger.LogWarning("UserControlLog initialized");
        }

        private void ButtonTrace_Click(object sender, RoutedEventArgs e)
        {
            logger.LogWarning("ButtonTrace as been Clicked!");
            textBoxLog.Text += "A message have been logged!" + Environment.NewLine;

            logger.LogTrace("This is a TRACE log"); // 0
            logger.LogDebug("This is a DEBUG log"); // 1
            logger.LogInformation("This is a INFORMATION log"); // 2
            logger.LogWarning("This is a WARNIG log"); // 3
            logger.LogError("This is a ERROR log"); // 4
            logger.LogCritical("This is a CRITICAL log"); // 5
            // 6 : None

        }

        private void ButtonDisplay_Click(object sender, RoutedEventArgs e)
        {
            // TODO: retreive the log file
            //textBoxLog.Text = File.ReadAllText(fileName);
        }
    }
}
