using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.W._2019.Gridushko._08
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PersonAccount firstOneAccount = new PersonAccount(123, "Gridushko", "Anton", TypeOfGrade.Basic);
            PersonAccount secondOneAccount = new PersonAccount(125, "Ivanova", "Irina", 100, 10, TypeOfGrade.Golden);

            PersonAccountService firstAccountsService = new PersonAccountService();
            firstAccountsService.AddNewAccount(firstOneAccount);
            firstAccountsService.AddNewAccount(secondOneAccount);

            firstAccountsService.CloseAccount(secondOneAccount);

            firstAccountsService.AddNewAccount(secondOneAccount);

            ConsoleWrite(firstAccountsService);
            Console.ReadLine();

            firstOneAccount.AccountRefill(200);
            secondOneAccount.WithdrawalsFromAccount(10);
            firstAccountsService.WriteDataToFile();

            PersonAccountService secondOneAccountsService = new PersonAccountService();
            secondOneAccountsService.ReadDataFromFile();

            ConsoleWrite(secondOneAccountsService);
            Console.ReadLine();
        }

        public static void ConsoleWrite(PersonAccountService accountsService)
        {
            for (int i = 0; i < accountsService.Count; i++)
            {
                Console.WriteLine(accountsService.ListAccounts.ElementAt(i).ToString());
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
