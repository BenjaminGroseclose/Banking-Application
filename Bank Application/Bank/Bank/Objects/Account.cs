using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.Objects
{
    class Account
    {
        public int AccountPK { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SocailSecurityNumber { get; set; }
        public double CheckingBalance { get; set; }
        public double SavingBalance { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
