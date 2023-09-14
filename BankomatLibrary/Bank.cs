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

        public bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Benvenuto inserire User\n\n\n");
            Console.Write("user:\t");
            string user = Console.ReadLine();

            if (user.Equals("Admin.Exit"))
            {
                return false;
            }

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

            if (!this.persona.ReturnState())
            {
                Console.Clear();
                Console.BackgroundColor= ConsoleColor.Red;
                Console.WriteLine("\n\nQuesto Account è temporaneamente bloccato.\nPremere qualunque tasto per tornare indietro");
                Console.ResetColor();
                Console.ReadKey();
                return true;
            }

            Console.Clear();
            Console.WriteLine("Benvenuto " + user + ", inserire password\n\n\n");
            Console.Write("password:\t");
            string password = Console.ReadLine();
            while (!Controllopassword(password) && this.persona.ControlloMaggioreAlLimite(maxTentativi))
            {
                this.persona.IncremenControllo();

                if (this.persona.ControlloMaggioreAlLimite(maxTentativi))
                {
                    this.persona.ChangeState();
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

            if(!this.persona.ControlloMaggioreAlLimite(maxTentativi))
            {
                this.persona.ResetControllo();
                while (MenuConto.viewConto(this.persona)) { }
            }
                
            return true;
        }

        #region Controlli

        public bool ControlloUser(string user)
        {
            Client x = this.clienti.Where(x => x.ReturnUserName() == user).FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            this.persona = x;
            return true;
        }

        public bool Controllopassword(string password)
        {
            return this.persona.ControlloPassword(password); // controllo se la password è uguale
        }

        #endregion

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
