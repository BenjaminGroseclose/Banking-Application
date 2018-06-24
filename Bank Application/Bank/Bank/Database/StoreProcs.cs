using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Windows;
using Bank_Application.Objects;

namespace Bank_Application.Database
{
    class StoredProcs
    {
        public string GetConnectionString()
        {
            //   return ConfigurationManager.ConnectionStrings["BankDatabase"].ConnectionString;
            return "";
        }

        internal bool LoginAuth(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("Get_LoginPassword");
                SqlDataReader dr;
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@username", username);
                connection.Open();

                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    MessageBox.Show(dr.GetString(0));
                }

            }

            return false;
        }

        internal bool CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        internal bool CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
