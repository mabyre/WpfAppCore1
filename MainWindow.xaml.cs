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
        UserControl1 ucc = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonTest1_Click( object sender, RoutedEventArgs e )
        {
            double uccWidth = MyMainWindow.Width;
            double uccHeight = MyMainWindow.Height;

            if ( (sender as Button).Name == "buttonTest1" )
            {
                ucc = new UserControl1();
                uccWidth = Column0.Width.Value + ucc.Width;
                uccHeight = ucc.Height;
                ContentControlArea.Content = ucc;
            }

            MyMainWindow.Width = uccWidth + 15; // margin
            MyMainWindow.Height = uccHeight + 35; // 30 it's the toolbar
        }
    }
}
