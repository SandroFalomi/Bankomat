using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatLibrary
{
    public class Bank
    {
        public List<Client> clienti;
        public Client persona;
        private static int maxTentativi = 3;

        public Bank()
        {
            clienti = new List<Client>();
        }

        public void Menu()
        {

            Console.WriteLine("Benvenuto inserire User\n\n\n");
            Console.Write("user:\t");
            string user = Console.ReadLine();
            while (!ControlloUser(user)) 
            {
                Console.Clear();
                Console.WriteLine("Benvenuto inserire User\n");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("user incorretto, prego riprovare\n");
                Console.ResetColor();
                Console.Write("user:\t");
                user = Console.ReadLine();
            }

            if (!ControlloState())
            {
                Console.Clear();
                Console.BackgroundColor= ConsoleColor.Red;
                Console.WriteLine("\n\nQuesto Account è temporaneamente bloccato.\nPremere qualunque tasto per tornare indietro");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Benvenuto " + user + ", inserire password\n\n\n");
            Console.Write("password:\t");
            string password = Console.ReadLine();
            while (!Controllopassword(password) && this.persona.controllo < maxTentativi)
            {
                this.persona.controllo++;

                if (this.persona.controllo == maxTentativi)
                {
                    this.persona.state = false;
                    Console.Clear();
                    Console.BackgroundColor= ConsoleColor.Red;
                    Console.WriteLine("\n\nHai raggiunto il limite di tentativi, l'account verrà bloccato\nPremere qualunque tasto per tornare indietro");
                    Console.ResetColor();   
                    Console.ReadKey();
                    break;
                }
                    

                Console.Clear();
                //(Console.BackgroundColor = ConsoleColor.Green)
                Console.WriteLine("Benvenuto " + user + ", inserire password\n");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("password incorretta, prego riprovare\n");
                Console.ResetColor();
                Console.Write("password:\t");
                password = Console.ReadLine();
            }

            if(!(this.persona.controllo >= maxTentativi))
                while (MenuConto.viewConto(this.persona)) { }

        }


        public bool ControlloUser(string user)
        {
            Client x = this.clienti.Where(x => x.userName == user).FirstOrDefault();
            if(x == null)
            {
                return false;
            }
            this.persona = x;
            return true;
        }

        public bool Controllopassword(string password)
        {
            return this.persona.password.Equals(password); // controllo se la password è uguale
        }

        public bool ControlloState()
        {
            return this.persona.state;
        }

        //public Client GivePersona(string user)
        //{
        //    return this.clienti.Where(x => x.userName == user).FirstOrDefault();
        //}



        #region metodi di test

        public void AddClient(Client x)
        {
            this.clienti.Add(x);
        }

        public void AddConto(Client x, double danaro)
        {
            BankAccount newAccount = new BankAccount(danaro);
            x.addBankAccount(newAccount);
        }

        #endregion
    }
}
