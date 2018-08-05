using System.Data;
using System.Data.SqlClient;
using System.Text;
using Bank.Objects;

namespace Bank.Database
{
    public class StoredProcs : DataConnection
    {
        StringBuilder errorMessages = new StringBuilder();

        public bool LoginAuth(string username, string password)
        {
            string _correctPassword;
            using (SqlConnection connection = new SqlConnection(SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand("ValidateLogin", connection))
            try
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
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                // Print Errors
                return false;
            }
        }

        public bool UniqueUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand("UniqueUsername", connection))
            try
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
            catch(SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                // Print Errors
                return false;
            }
        }

        internal bool CreateAccount(Account account)
        {

            using (SqlConnection connection = new SqlConnection(SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand("Account_Save", connection))
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", account.Username);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@TotalBalance", account.TotalBalance);
                command.ExecuteNonQuery();

                return true; // want to implement sql error handling later

            }
            catch(SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                // Print Errors
                return false;
            }
        }

        internal bool CreateCustomer(Customer customer, string username)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand("Customer_Save", connection))
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@Middle", customer.Middle);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Gender", customer.Gender);
                command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Username", username);
                command.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                // Print Errors
                return false;
            }
        }

    }
}
