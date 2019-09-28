using System;
using System.Collections.Generic;
using System.Linq;

namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Methods to work with account list
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        private IGenerator generator;
        private IRepository repository;
        private IBonusCounter bonusCounter;

        public BankAccountService(IRepository repository, IGenerator generator, IBonusCounter bonusCounter)
        {
            this.Repository = repository;
            this.Generator = generator;
            this.BonusCounter = bonusCounter;
        }

        /// <summary>
        /// Generates Id 
        /// </summary>
        private IGenerator Generator
        {
            get => this.generator;

            set
            {
                this.generator = value;
            }
        }

        /// <summary>
        /// Enables objects of BankAccount type.
        /// </summary>
        private IRepository Repository
        {
            get => this.repository;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.repository = value;
            }
        }

        /// <summary>
        /// The bonus counter.
        /// </summary>
        private IBonusCounter BonusCounter
        {
            get => this.bonusCounter;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.bonusCounter = value;
            }
        }

        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<BankAccount>.</returns>
        public IEnumerable<BankAccount> GetAll()
        {
            return this.Repository.GetAll().Select(item => item.ToBankAccount());
        }

        /// <summary>
        /// Enables account.
        /// </summary>
        public void Open(string nameOwner, string ownerSurname, double amount, GradingVariant gradingType)
        {
            int id = this.Generator.GenerateId();

            BankAccount bankAccount = new BankAccount(id, nameOwner, ownerSurname, 0, 0, gradingType);

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.GradingVariants);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.PointsForBonus = this.BonusCounter.Increase(bankAccount.PointsForBonus);

            this.Repository.Add(bankAccount.ToAccount());
        }

        /// <summary>
        /// Disables account.
        /// </summary>
        public void Close(int id)
        {
            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            this.Repository.Delete(bankAccount.ToAccount());
        }

        public void Refill(int id, double amount)
        {
            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.GradingVariants);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.PointsForBonus = this.BonusCounter.Increase(bankAccount.PointsForBonus);

            this.Repository.Edit(bankAccount.ToAccount());
        }

        /// <summary>
        /// Withdraws account
        /// </summary>
        public void Withdraw(int id, double amount)
        {
            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.GradingVariants);

            bankAccount.Amount = bankAccount.Amount - amount;
            bankAccount.PointsForBonus = this.BonusCounter.Reduction(bankAccount.PointsForBonus);

            this.Repository.Edit(bankAccount.ToAccount());
        }

    }
}