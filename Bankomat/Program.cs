using BankomatLibrary;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            double costante = 1000;

            //------------------------------------------------------------------------------------//
            // Parte di testing //

            Client admin = new Client("admin", "0000");
            Client sandro = new Client("sandro", "951478632");
            Client paolo = new Client("paolo", "1");



            bank.AddClient(admin);
            bank.AddClient(sandro);
            bank.AddClient(paolo);

            bank.AddConto(admin, costante);
            bank.AddConto(paolo, costante);
            bank.AddConto(sandro, costante);

            //------------------------------------------------------------------------------------//

            while (true) 
            {
                Console.Clear();
                bank.Menu();
            }

        }
    }
}
