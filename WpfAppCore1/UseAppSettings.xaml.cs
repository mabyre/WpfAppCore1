using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Logique d'interaction pour UseAppSettings.xaml
    /// </summary>
    public partial class UseAppSettings : UserControl
    {
        string config = App.Configuration.GetSection("MyTextInAppSettings").Value;

        public UseAppSettings()
        {
            InitializeComponent();

            textBoxDisplay.Text = config;

            textBoxDisplay.Text += Environment.NewLine;
            textBoxDisplay.Text += "Logging:LogLevel:Default: ";
            textBoxDisplay.Text += App.Configuration.GetSection("Logging:LogLevel:Default").Value;

            textBoxDisplay.Text += Environment.NewLine;
            textBoxDisplay.Text += "Logging:Debug:LogLevel:Default: ";
            textBoxDisplay.Text += App.Configuration.GetSection("Logging:Debug:LogLevel:Default").Value;

            textBoxDisplay.Text += Environment.NewLine;
            textBoxDisplay.Text += "- FileLogger Logging:File:LogLevel: ";
            textBoxDisplay.Text += App.Configuration.GetSection("Logging:File:LogLevel").Value;

            textBoxDisplay.Text += Environment.NewLine;
            textBoxDisplay.Text += "- FileLogger Logging:Debug:LogLevel:Folder: ";
            textBoxDisplay.Text += App.Configuration.GetSection("Logging:File:Folder").Value;
        }
    }
}
