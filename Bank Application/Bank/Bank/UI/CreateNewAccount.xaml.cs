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
using System.Windows.Shapes;
using Bank.Database;
using Bank.Objects;


namespace Bank.UI
{
    /// <summary>
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : Window
    {
        public CreateNewAccount()
        {
            InitializeComponent();
        }

        private void CancelNewAccount(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void SaveNewAccount(object sender, RoutedEventArgs e)
        {

            if (ValidateInput())
            {

            }


        }

        private bool ValidateInput()
        {
            if(!NecessaryInfo())
            {
                MessageBox.Show("Please Enter all the required fields", "Incorrect Input");
                return false;
            }

            if (!MatchingPasswords())
            {
                MessageBox.Show("Confirm Password does not match Password.", "Incorrect Input");
                return false;
            }

            if(!UniqueUsername())
            {
                MessageBox.Show("Username is already in use please try again.", "Incorrect Input");
                return false;
            }

            return true;
        }

        private bool NecessaryInfo()
        {
            if (txtFirstName.Text == "") return false;
            if (txtLastName.Text == "") return false;
            if (txtPhone.Text == "") return false;
            if (dateDateOfBirth.Text == "") return false;
            if (txtUsername.Text == "") return false;
            if (txtPassword.Text == "") return false;
            if (txtPasswordConfirm.Text == "") return false;
            return true;
        }

        private bool MatchingPasswords()
        {
            if (txtPassword.Text == txtPasswordConfirm.Text)
                return true;
            return false;
        }

        private bool UniqueUsername()
        {
            StoredProcs storedProcs = new StoredProcs();
            return storedProcs.StoredProc_UniqueUsername(txtUsername.Text);
        }

        //private bool NewCustomer()
        //{

        //}

        //private bool NewAccount()
        //{

        //}
    }
}
