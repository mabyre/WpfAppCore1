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
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SetTextProperty =
         DependencyProperty.Register( "SetText", typeof( string ), typeof( UserControl2 ), new
            PropertyMetadata( "", new PropertyChangedCallback( OnSetTextChanged ) ) );

        public string SetText
        {
            get { return (string)GetValue( SetTextProperty ); }
            set { SetValue( SetTextProperty, value ); }
        }

        private static void OnSetTextChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            UserControl2 uc = d as UserControl2;
            uc.OnSetTextChanged( e );
        }

        private void OnSetTextChanged( DependencyPropertyChangedEventArgs e )
        {
            TextBox1.Text = e.NewValue.ToString();
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            this.SetText = "Say Hello to the world using DependencyProperty!";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.SetText = "You clicked on Pass mouse over button";
        }
    }
}
