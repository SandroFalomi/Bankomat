using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatLibrary
{
    internal static class MenuConto
    {
        public static bool viewConto(Client persona)
        {
            BankAccount ba = persona.bankAccount;
            string input = string.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine("Account con iban:\t" + persona.bankAccount.iban + "\n\n");
                Console.WriteLine("Cosa desideri fare?");
                Console.WriteLine("\n1) Prelevare");
                Console.WriteLine("\n2) Depositare");
                Console.WriteLine("\n3) Saldo");
                Console.WriteLine("\nE) Exit");
                ConsoleKeyInfo x = Console.ReadKey();
                input = x.KeyChar + "";
            } while (input is not "1" and not "2" and not "3" && !input.ToUpper().Equals("E"));

            if (input.ToUpper().Equals("E"))
            {
                return false;
            }


            Console.Clear();

            double danaro = 0;

            switch (input)
            {
                case "1":
                    Console.WriteLine("Quanto desidera prelevare?\n\n\n");
                    double.TryParse(Console.ReadLine(), out danaro);
                    while (!ba.Prelievo(danaro))
                    {
                        Console.Clear();
                        Console.WriteLine("Quanto desidera prelevare?\n");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Impossibile prelevare tale cifra prego riprovare (premere E per uscire)\n");
                        Console.ResetColor();
                        string tmp = Console.ReadLine();
                        if(tmp.ToUpper() == "E")
                        {
                            return true;
                        }
                        double.TryParse(tmp, out danaro);
                    }
                    break;
                case "2":
                    Console.WriteLine("Quanto desidera depositare\n\n\n");
                    double.TryParse(Console.ReadLine(), out danaro);
                    while (!ba.Versamento(danaro))
                    {
                        Console.Clear();
                        Console.WriteLine("Quanto desidera depositare?\n");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Impossibile Depositare tale cifra prego riprovare (premere E per uscire)\n");
                        Console.ResetColor();
                        string tmp = Console.ReadLine();
                        if (tmp.ToUpper() == "E")
                        {
                            return true;
                        }
                        double.TryParse(tmp, out danaro);
                    }

                    break;
            }

            Console.Clear();

            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(ba.ViewSaldo());
            Console.ResetColor();

            Console.WriteLine("\nPremere qualunque tasto per andare avanti...\n");
            Console.ReadKey();
            return true;
        }
    }
}
