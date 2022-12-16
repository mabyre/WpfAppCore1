using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();

            // Simulate a clic on button to load the UserControl
            // you want at the beginning
            //
            Button b = new Button();
            b.Name = "buttonTest1";
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
            }

            if ( (sender as Button).Name == "buttonTest2" )
            {
                UserControl2 ucc = new UserControl2();
                uccWidth = Column0.Width.Value + ucc.Width;
                uccHeight = ucc.Height;
                ucc.SetText = "Hello World!"; // DependencyProperty
                ContentControlArea.Content = ucc;
            }

            MyMainWindow.Width = uccWidth + 15; // margin
            MyMainWindow.Height = uccHeight + 35; // 30 it's the toolbar
        }
    }
}
