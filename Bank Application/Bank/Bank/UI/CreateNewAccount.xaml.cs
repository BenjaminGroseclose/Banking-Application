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

using Bank_Application.Objects;


namespace Bank.UI
{
    /// <summary>
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : Window
    {
        private List<String> fields;

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
                //AccountCreation accountCreation = new AccountCreation();
                Customer customer = new Customer();
                Account account = new Account();

                customer = NewCustomer();
                account = NewAccount();

                //if (accountCreation.UploadToDatabase(customer, account))
                //    MessageBox.Show("Account Creation", customer.FirstName + " your Account has been created");
                //else
                //    MessageBox.Show("Account Creation", customer.FirstName + " we were not able to save your account to our Database, please try again");                
            }
            else
            {
                MessageBox.Show("Incorrect Input", "Please Enter all the required fields");
                InvalidInput();

            }
        }

        private bool ValidateInput()
        {            
            if (txtFirstName.Text == null) fields.Add("txtFirstName");
            if (txtLastName.Text == null) fields.Add("txtLastName");
            if (txtPhone.Text == null) fields.Add("txtPhone");
            if (dateDateOfBirth.Text == null) fields.Add("dateDateOfBirth");
            if (txtUsername.Text == null) fields.Add("txtUsername");
            if (txtPassword.Text == null) fields.Add("txtPassword");
            if (txtPasswordConfirm.Text == null) fields.Add("txtPasswordConfirm");

            if (fields.Any())
                return true;
            return false;
        }

        private void InvalidInput()
        {
            /*
            Looking into how to make the background of text boxes red. 
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "txtFirstName":
                        txtFirstName;
                            break;
                }
            }
            */
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
