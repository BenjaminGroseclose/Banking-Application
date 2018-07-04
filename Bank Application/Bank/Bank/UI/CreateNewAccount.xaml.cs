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

using Bank.Objects;


namespace Bank.UI
{
    /// <summary>
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : Window
    {
        private List<String> fields;
        private string fieldString = "";

        public CreateNewAccount()
        {
            InitializeComponent();
        }

        private void CancelNewAccount(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void SaveNewAccount(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if(MatchingPasswords())
                {
                    Customer customer = new Customer();
                    Account account = new Account();
                }
                else
                {
                    MessageBox.Show("Incorrect Input", "Confirm Password does not match Password.");

                }
            }
            else
            {
                foreach(var field in fields)
                {
                    ConcatFieldString(field);
                }
                MessageBox.Show("Incorrect Input", "Please Enter all the required fields" + fieldString);

            }
        }

        private void ConcatFieldString(string field)
        {
            switch(field)
            {
                case "txtFirstName":
                    fieldString = string.Concat(fieldString, "/nFirst Name");
                    break;
                case "txtLastName":
                    fieldString = string.Concat(fieldString, "/nLast Name");
                    break;
                case "txtPhone":
                    fieldString = string.Concat(fieldString, "/nPhone");
                    break;
                case "dateDateOfBirth":
                    fieldString = string.Concat(fieldString, "/nDate of Birth");
                    break;
                case "txtUsername":
                    fieldString = string.Concat(fieldString, "/nUsername");
                    break;
                case "txtPassword":
                    fieldString = string.Concat(fieldString, "/nPassword");
                    break;
                case "txtPasswordConfirm":
                    fieldString = string.Concat(fieldString, "/nConfirm Password");
                    break;
            }

        }

        private bool ValidateInput()
        {            
            if (txtFirstName.Text == "") fields.Insert(0, "txtFirstName");
            if (txtLastName.Text == "") fields.Insert(0, "txtLastName");
            if (txtPhone.Text == "") fields.Insert(0, "txtPhone");
            if (dateDateOfBirth.Text == "") fields.Insert(0, "dateDateOfBirth");
            if (txtUsername.Text == "") fields.Insert(0, "txtUsername");
            if (txtPassword.Text == "") fields.Insert(0, "txtPassword");
            if (txtPasswordConfirm.Text == "") fields.Insert(0, "txtPasswordConfirm");

            if (fields.Any())
                return true;
            return false;
        }

        private bool MatchingPasswords()
        {
            if (txtPassword.Text == txtPasswordConfirm.Text)
                return true;
            return false;
        }

        private Customer NewCustomer()
        {
            Customer customer = new Customer();

            return customer;
        }

        private Account NewAccount()
        {
            Account account = new Account();

            return account;
        }
    }
}
