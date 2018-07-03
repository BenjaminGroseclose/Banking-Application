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

using Bank_Application.Database;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StoredProcs storedProcs = new StoredProcs();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void clickLogin(object sender, RoutedEventArgs e)
        {
            if(ValidateLogin())
            {
                if (storedProcs.LoginAuth(txtUsername.Text, txtPassword.Text))
                    // Access Granted Go to Main Window. 
                else
                    MessageBox.Show("Incorrect Username or Password", "You username or password were incorrect please try again.");
            }

        }

        private void clickCreateNewAccount(object sender, RoutedEventArgs e)
        {

        }

        private bool ValidateLogin()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Incorrect Input", "Please enter both your Username and Password");
                return false;
            }
                
            return true;
        }
    }
}
