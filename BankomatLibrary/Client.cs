using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatLibrary
{
    public class Client
    {
        private BankAccount bankAccount;
        private int controllo = 0;
        private string userName;
        private string password;
        private bool state = true;

        public Client(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public void addBankAccount(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }
        public void ChangeState()
        {
            this.state = !this.state;
        }

        #region Operazioni Sul Controllo
        public void IncremenControllo()
        {
            this.controllo++;
        }

        public void ResetControllo()
        {
            this.controllo = 0;
        }
        #endregion

        #region Controlli

        public bool ControlloPassword(string password)
        {
            return this.password.Equals(password);
        }

        public bool ControlloMaggioreAlLimite(int max) // return true se il parametro è uguale 
        {
            return this.controllo >= max;
        }

        #endregion

        #region Return
        public bool ReturnState()
        {
            return this.state;
        }

        public BankAccount ReturnBankAccount()
        {
            return this.bankAccount;
        }

        public string ReturnUserName()
        {
            return this.userName;
        } 
        #endregion

    }
}
