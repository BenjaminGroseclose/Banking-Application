using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.Objects
{
    class Customer
    {

        public int CustomerPK { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public int AccountFK { get; set; }
        public DateTime CreatedDate { get; set; }

        public Customer GetCustomerData(int CustomerPK)
        {
            var customer = new Customer();

            // return a customer from the database when given the CustomerPK

            return customer;
        }

        //public void createCustomer(string Firstname,
        //                           string LastName,
        //                           char Gender,
        //                           DateTime DOB,
        //                           string Phone,
        //                           string Middle = "")
        //{

        //    using (SqlConnection connection = new SqlConnection(
        //        ConfigurationManager.ConnectionStrings["BankDatabase"].ConnectionString))
        //    using (SqlCommand command = new SqlCommand())
        //    {

        //    }
        //}

    }
}
