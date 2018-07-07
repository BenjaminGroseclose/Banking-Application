using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bank.Database;

using System.Data.SqlClient;
using System.Data;

namespace BankUnitTest.LoginTests
{
    /// <summary>
    /// Summary description for ValidateLoginTest
    /// </summary>
    [TestClass]
    public class ValidateLoginTest
    {

        [TestMethod]
        public void GivenIncorrectLoginInformation_UserCanNotAccessApplication()
        {
            //Arrange
            StoredProcs storedProcs = new StoredProcs();
            string incorrectUsername = "12345";
            string incorrectPassword = "67890";

            //Act
            bool actual = storedProcs.StoredProc_LoginAuth(incorrectUsername, incorrectPassword);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GivenCorrectLoginInformation_UserCanAccessApplication()
        {
            //Arrange
            StoredProcs storedProcs = new StoredProcs();
            string correctUsername = GetUsername();
            string correctPassword = GetPassword(correctUsername);

            //Act
            bool actual = storedProcs.StoredProc_LoginAuth(correctUsername, correctPassword);

            //Assert
            Assert.IsTrue(actual);
        }

        private string GetUsername()
        {
            string query = "SELECT TOP 1 a.Username FROM Account AS a";
            DataConnection dataConnection = new DataConnection();
            using (SqlConnection connection = new SqlConnection(dataConnection.SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        return dataReader.GetString(0);
                    }

                }
            }
            return "";
        }

        private string GetPassword(string username)
        {
            string query = "SELECT a.Password FROM Account AS a WHERE a.Username = '" + username + "'";
            DataConnection dataConnection = new DataConnection();
            using (SqlConnection connection = new SqlConnection(dataConnection.SqlConnection().ToString()))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        return dataReader.GetString(0);
                    }

                }
            }
            return "";
        }
    }
}
