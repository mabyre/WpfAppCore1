using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        FileLogger file = new FileLogger( "log.txt" );

        public UserControl1()
        {
            InitializeComponent();
            Logger.WriteMessage += LoggingMethods.LogToConsole; 
            Logger.WriteMessage += LoggingMethods.LogToTrace;
            Logger.LogLevel = Severity.Verbose; // by default set to Warning
        }

        private void Button1_Click( object sender, RoutedEventArgs e )
        {
            Logger.LogMessage( Severity.Verbose, "UserControl1", "Click on button1" );
        }
    }
}
