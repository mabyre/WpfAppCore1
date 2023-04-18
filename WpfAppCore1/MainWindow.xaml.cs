using Microsoft.Extensions.Logging;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public MainWindow(ILoggerFactory loggerFactory)
        {
            InitializeComponent();

            _logger = loggerFactory.CreateLogger<MainWindow>();
            _loggerFactory = loggerFactory;


            // Simulate a clic on button to load the UserControl
            // you want at the beginning
            //
            Button b = new Button();
            b.Name = "buttonLog";
            button_Click( b, null );
        }

        private void button_Click( object sender, RoutedEventArgs e )
        {
            double uccWidth = MyMainWindow.Width;
            double uccHeight = MyMainWindow.Height;

            if ( (sender as Button).Name == "buttonTest1" )
            {
                UserControl1 ucc = new UserControl1();
                uccWidth = Column0.Width.Value + ucc.Width;
                uccHeight = ucc.Height;
                ContentControlArea.Content = ucc;

                textBlockTitle.Text = "Test1: Use Logger Tool";
            }

            if ( (sender as Button).Name == "buttonTest2" )
            {
                UserControl2 ucc = new UserControl2();
                uccWidth = Column0.Width.Value + ucc.Width;
                uccHeight = ucc.Height;
                ucc.SetText = "Hello World!"; // DependencyProperty
                ContentControlArea.Content = ucc;

                textBlockTitle.Text = "Demonstrate the use of Dependency Property";
            }

            if ((sender as Button).Name == "buttonLog")
            {
                UserControlLog ucc = new UserControlLog(_loggerFactory);
                uccWidth = Column0.Width.Value + ucc.Width;
                uccHeight = ucc.Height;
                ContentControlArea.Content = ucc;

                textBlockTitle.Text = "Logs using .NET Core standard";
            }

            if ((sender as Button).Name == "buttonAppSettings")
            {
                UseAppSettings ucc = new UseAppSettings();
                uccWidth = Column0.Width.Value + ucc.Width;
                uccHeight = ucc.Height;
                ContentControlArea.Content = ucc;

                textBlockTitle.Text = "Read appsettings.json file";
            }

            MyMainWindow.Width = uccWidth + 40; // margin

            // 30 it's the window's toolbar
            // 40 it's title bar
            // 10 margin
            MyMainWindow.Height = uccHeight + 30 + 40 + 10; 
        }
    }
}
