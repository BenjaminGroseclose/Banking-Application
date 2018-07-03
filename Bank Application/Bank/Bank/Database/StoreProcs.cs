using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Bank_Application.Objects;

namespace Bank_Application.Database
{
    class StoredProcs
    {
        

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BankDatabase"].ConnectionString;
        }

        internal bool LoginAuth(string username, string password)
        {
            string _correctPassword;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT Password FROM Account WHERE Username ='"+username+"'" , connection))
            {
                
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if(dr.Read())
                {
                    _correctPassword = dr.GetString(0);
                }
                else
                    return false;

                connection.Close();

                if (_correctPassword == password)
                    return true;

            }

            return false;
        }

        internal bool CreateAccount(Account account)
        {
            return false;
        }

        internal bool CreateCustomer(Customer customer)
        {
            return false;
        }
    }
}
