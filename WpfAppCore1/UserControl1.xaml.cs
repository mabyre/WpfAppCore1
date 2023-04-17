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
using Tools.Logger;

namespace WpfAppCore1
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        static string fileName = "log.txt";
        Tools.Logger.FileLogger file = new Tools.Logger.FileLogger( fileName );

        public UserControl1()
        {
            InitializeComponent();
            Logger.WriteMessage += LoggingMethods.LogToConsole; 
            Logger.WriteMessage += LoggingMethods.LogToTrace;
            Logger.LogLevel = Severity.Verbose; // by default set to Warning
        }

        private void ButtonTrace_Click( object sender, RoutedEventArgs e )
        {
            Logger.LogMessage( Severity.Verbose, "UserControl1", "Click on Trace" );
            textBoxLog.Text += "Trace have been logged!" + Environment.NewLine;
        }

        private void ButtonDisplay_Click(object sender, RoutedEventArgs e)
        {
            textBoxLog.Text = File.ReadAllText(fileName);
        }
    }
}
