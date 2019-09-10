using System;
using System.Collections.Generic;
using System.Linq;

namespace NET.A._2019.Gridushko._15
{
    public class AccountsDbStorage : IRepository
    {
        private BankContext context;
        public AccountsDbStorage()
        {
            this.context = new BankContext();
        }
        public IEnumerable<Account> GetAll()
        {
            return context.BankAccounts.ToArray().Select(item => item.ToAccount());
        }
        public Account Get(int id)
        {
            return context.BankAccounts.FirstOrDefault(item => item.Id == id).ToAccount();
        }

        public void Add(Account account)
        {
            context.BankAccounts.Add(account.ToBankAccount());
            context.SaveChanges();
        }

        public void Update(Account account)
        {
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).NameOwner = account.NameOwner;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).SurnameOwner = account.SurnameOwner;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).Amount = Convert.ToDecimal(account.Amount);
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).PointsForBonus = account.PointsForBonus;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).GradingVariants = account.GradingVariants;
            context.SaveChanges();
        }
        public void Delete(Account account)
        {
            context.BankAccounts.Remove(account.ToBankAccount());
            context.SaveChanges();
        }
    }
}
