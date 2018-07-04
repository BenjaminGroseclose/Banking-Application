using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Bank.Objects;

namespace Bank.Database
{
    public class StoredProcs : DataConnection
    {

        public bool LoginAuth(string username, string password)
        {
            string _correctPassword;
            using (SqlConnection connection = new SqlConnection(SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand("ValidateLogin" , connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", username);
                SqlParameter retval = command.Parameters.Add("@password", SqlDbType.VarChar, 50);
                retval.Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                _correctPassword = command.Parameters["@password"].Value.ToString();
                if (password == _correctPassword)
                    return true;
                else
                    return false;

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
