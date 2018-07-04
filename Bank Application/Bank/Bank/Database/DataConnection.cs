using System;
using System.Data.SqlClient;
using System.Windows;

namespace Bank.Database
{
    public class DataConnection
    {

        public SqlConnectionStringBuilder SqlConnection()
        {
            try
            {
                SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
                connectionString.DataSource = "groseclose.database.windows.net";
                connectionString.UserID = "BGroseclose";
                connectionString.Password = "Hward777";
                connectionString.InitialCatalog = "Bank";

                return connectionString;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Unable to connect to the Database.", "Database Connection");
                Application.Current.Shutdown();
            }

            return null;
        }
    }
      
}
