using System.Data;
using System.Data.SqlClient;

using Bank.Objects;

namespace Bank.Database
{
    public class StoredProcs : DataConnection
    {

        public bool StoredProc_LoginAuth(string username, string password)
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
                return false;

            }
        }

        public bool StoredProc_UniqueUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand("UniqueUsername", connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", username);
                SqlParameter retval = command.Parameters.Add("Return Value", SqlDbType.Int);
                retval.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();
                if ((int)command.Parameters["Return Value"].Value == 1)
                    return true;
                return false;

            }
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
