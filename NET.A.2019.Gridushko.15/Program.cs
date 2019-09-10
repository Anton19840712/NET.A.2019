using System;
using NET.A._2019.Gridushko._15.BLL.Interface.Interfaces;
using Ninject;

namespace NET.A._2019.Gridushko._15
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigureResolver();
        }

        public static void Main(string[] args)
        {
            IBankAccountService accountService = Resolver.Get<IBankAccountService>();

            accountService.Open("Videneeva", "Anna", 100, GradingVariant.Gold);
            accountService.Open("Frolov", "Slava", 200, GradingVariant.Platinum);
            accountService.Open("Ageeva", "Alina", 300, GradingVariant.Base);
            accountService.Open("Stupen", "Maria", 400, GradingVariant.Gold);
            accountService.Open("Eroshencova", "Polina", 500, GradingVariant.Base);
            accountService.Open("Kutircina", "Elizaveta", 600, GradingVariant.Platinum);

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Refill(account.Id, 100);
            }

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Withdrawal(account.Id, 10);
            }

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Close(account.Id);
            }
        }
        private static void Display(IBankAccountService accountService)
        {
            foreach (var account in accountService.GetAll())
            {
                Console.WriteLine(account);
            }
        }
    }
}