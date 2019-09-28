using System;
using System.Collections.Generic;
using System.Linq;

namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Implements methods to work with database.
    /// </summary>
    public class AccountsDbStorage : IRepository
    {
        /// <summary>
        /// Context data.
        /// </summary>
        private BankContext context;

        /// <summary>
        /// Simple instance initialization
        /// </summary>
        public AccountsDbStorage()
        {
            this.context = new BankContext();
        }

        /// <summary>
        /// Give us a ist of all objects.
        /// </summary>
        public IEnumerable<Account> GetAll()
        {
            return context.BankAccounts.ToArray().Select(item => item.ToAccount());
        }

        /// <summary>
        /// Gets one object by id.
        /// </summary>
        public Account Get(int id)
        {
            return context.BankAccounts.FirstOrDefault(item => item.Id == id).ToAccount();
        }

        /// <summary>
        /// Adds object to storage.
        /// </summary>

        public void Add(Account account)
        {
            context.BankAccounts.Add(account.ToBankAccount());
            context.SaveChanges();
        }

        /// <summary>
        /// Edites the object data.
        /// </summary>
        public void Edit(Account account)
        {
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).NameOwner = account.NameOwner;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).SurnameOwner = account.SurnameOwner;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).Amount = Convert.ToDecimal(account.Amount);
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).PointsForBonus = account.PointsForBonus;
            context.BankAccounts.FirstOrDefault(item => item.Id == account.Id).GradingVariants = account.GradingVariants;
            context.SaveChanges();
        }

        /// <summary>
        /// Removes object data.
        /// </summary>

        public void Delete(Account account)
        {
            context.BankAccounts.Remove(account.ToBankAccount());
            context.SaveChanges();
        }
    }
}
