using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatLibrary
{
    public class Client
    {
        public BankAccount bankAccount;
        public int controllo = 0;
        public string userName;
        public string password;
        public bool state = true;

        public Client(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public void addBankAccount(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }
    }
}
