using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatLibrary
{
    public class BankAccount
    {
        public string iban;
        public double saldo;

        public BankAccount(double saldo)
        {
            //genero casualmente un iban (per questioni di tempo uso un numero random e non una GUID)
            this.iban = Convert.ToString(new Random().Next(999999999));
            this.saldo = saldo;
        }

        public BankAccount(string iban, double saldo)
        {
            this.saldo = saldo;
            this.iban = iban;
        }

        public string GetSaldo() 
        {
            return Convert.ToString(this.saldo);
        }

        public bool Versamento(double somma) 
        {
            if(somma <= 0)
            {
                return false;
            }
            this.saldo += somma;
            return true;
        }

        public bool Prelievo(double saldo)
        {
            if(saldo <= 0)
            {
                return false;
            }

            if(saldo > this.saldo)
            {
                return false;
            }

            this.saldo -= saldo;
            return true;
        }

        public string ViewSaldo()
        {
            return "Data " + (DateTime.Now.ToString()) + "\nSaldo Attuale: " + this.saldo;
        }
    }
}
