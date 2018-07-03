using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bank.Database
{
    class DataConnection
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["BankDatabase"].ConnectionString;
    }
}
