using System;
using Ninject;

namespace NET.A._2019.Gridushko._22
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

            accountService.Open("Ivanov", "Ivan", 400, GradingVariant.Golden);
            accountService.Open("Petrov", "Anton", 500, GradingVariant.Base);
            accountService.Open("Frolov", "Ignat", 600, GradingVariant.Platinus);

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Refill(account.Id, 90);
            }

            Display(accountService);

            foreach (var account in accountService.GetAll())
            {
                accountService.Withdraw(account.Id, 12);
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