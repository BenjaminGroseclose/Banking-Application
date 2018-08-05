using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Objects
{
    public class Account
    {
        public int AccountPK { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double TotalBalance { get; set; }
        public DateTime CreatedDate { get; set; }

        public GetAccountByUsername(string username)
        {

        }

        private Account(){ }

        private Account DataLoader(DataReader dr)
        {
            Account account = new Account();
            account.AccountPK
        }

    }
}
