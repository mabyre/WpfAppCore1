using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FileLogger.Logging;

namespace WpfAppCore1
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services => {
                    services.AddSingleton<App>();
                    services.AddSingleton<MainWindow>();
                })
                .ConfigureLogging(logging =>
                {
                    //logging.ClearProviders();
                    logging.AddFileLogger();
                    //logging.AddFileLogger(options => {
                    //    options.MaxFileSizeInMB = 5;
                    //});
                })
                .Build();

            //// Logging configuration
            ////
            //var _host = Host.CreateDefaultBuilder()

            //    .Build();

            var app = host.Services.GetService<App>();
            app.Run();
        }
    }
}
