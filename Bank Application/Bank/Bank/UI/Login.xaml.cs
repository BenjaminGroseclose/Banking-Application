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

using Bank.Database;

namespace Bank.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        StoredProcs storedProcs = new StoredProcs();

        public Login()
        {
            InitializeComponent();
        }

        private void clickLogin(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if(ValidateLogin())
            {
                if (storedProcs.StoredProc_LoginAuth(txtUsername.Text, txtPassword.Password))
                {
                    mainWindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("You username or password were incorrect please try again.", "Incorrect Username or Password");
            }

        }

        private void clickCreateNewAccount(object sender, RoutedEventArgs e)
        {
            CreateNewAccount createNewAccount = new CreateNewAccount();
            createNewAccount.Show();
        }

        private bool ValidateLogin()
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Please enter both your Username and Password", "Incorrect Input");
                return false;
            }
                
            return true;
        }
    }
}
