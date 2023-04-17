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

            //
            // Log all level of logs
            //
            logger.LogTrace("This is a TRACE log"); // 0
            logger.LogDebug("This is a DEBUG log"); // 1
            logger.LogInformation("This is a INFORMATION log"); // 2
            logger.LogWarning("This is a WARNIG log"); // 3
            logger.LogError("This is a ERROR log"); // 4
            logger.LogCritical("This is a CRITICAL log"); // 5
            // 6 : None

            //
            // Structured log from:
            // https://github.com/NLog/NLog/wiki/How-to-use-structured-logging
            //

            Object o = null;

            logger.LogInformation("Test {value1}", o); // null case. Result:  Test NULL
            logger.LogInformation("Test {value1}", new DateTime(2018, 03, 25)); // datetime case. Result:  Test 25-3-2018 00:00:00 (locale TString)
            logger.LogInformation("Test {value1}", new List<string> { "a", "b" }); // list of strings. Result: Test "a", "b"
            logger.LogInformation("Test {value1}", new[] { "a", "b" }); // array. Result: Test "a", "b"
            logger.LogInformation("Test {value1}", new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } }); // dict. Result:  Test "key1"=1, "key2"=2

            //var order = new Order
            //{
            //    OrderId = 2,
            //    Status = OrderStatus.Processing
            //};

            //logger.LogInformation("Test {value1}", order);  // object Result: Test MyProgram.Program+Order
            //logger.LogInformation("Test {@value1}", order); // object Result: Test {"OrderId":2, "Status":"Processing"}
            logger.LogInformation("Test {value1}", new { OrderId = 2, Status = "Processing" });  // anonymous object. Result: Test { OrderId = 2, Status = Processing }
            logger.LogInformation("Test {@value1}", new { OrderId = 2, Status = "Processing" }); // anonymous object. Result: Test {"OrderId":2, "Status":"Processing"}

            //
            // https://learn.microsoft.com/en-us/dotnet/core/extensions/custom-logging-provider
            //
            logger.LogDebug(1, "Does this line get hit?");    // Not logged
            logger.LogInformation(3, "Nothing to see here."); // Logs in ConsoleColor.DarkGreen
            logger.LogWarning(5, "Warning... that was odd."); // Logs in ConsoleColor.DarkCyan
            logger.LogError(7, "Oops, there was an error.");  // Logs in ConsoleColor.DarkRed
            logger.LogTrace(5, "== 120.");                    // Not logged
        }

        private void ButtonDisplay_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FileLogger.Logging.FileLoggerProvider.FilePath;
            textBoxLog.Text = File.ReadAllText(fileName);
        }
    }
}
