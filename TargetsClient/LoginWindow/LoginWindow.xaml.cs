using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TargetsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : FocusRoutedEvents
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as PasswordBox).Password == "")
                (sender as PasswordBox).Tag = "Enter your password";
            else
            {
                (sender as PasswordBox).Tag = "";
                ((sender as PasswordBox).DataContext as LoginWindowViewModel).Password = (sender as PasswordBox).Password;
            }

        }




    }
}
