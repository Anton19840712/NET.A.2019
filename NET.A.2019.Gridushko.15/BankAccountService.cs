using NET.A._2019.Gridushko._15.BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NET.A._2019.Gridushko._15
{
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
        private IGenerator Generator
        {
            get => this.generator;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.generator = value;
            }
        }
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
        public IEnumerable<BankAccount> GetAll()
        {
            return this.Repository.GetAll().Select(item => item.ToBankAccount());
        }
        public void Open(string ownerName, string ownerSurname, double amount, GradingVariant gradingType)
        {
            int id = this.Generator.GenerateId();

            BankAccount bankAccount = new BankAccount(id, ownerName, ownerSurname, 0, 0, gradingType);

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.GradingVariants);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.PointsForBonus = this.BonusCounter.Increase(bankAccount.PointsForBonus);

            this.Repository.Add(bankAccount.ToAccount());
        }
        public void Close(int id)
        {
            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.Repository.Delete(bankAccount.ToAccount());
        }
        public void Refill(int id, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is not be negative.", nameof(amount));
            }

            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.GradingVariants);

            bankAccount.Amount = bankAccount.Amount + amount;
            bankAccount.PointsForBonus = this.BonusCounter.Increase(bankAccount.PointsForBonus);

            this.Repository.Update(bankAccount.ToAccount());
        }
        public void Withdrawal(int id, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is not be negative.", nameof(amount));
            }

            BankAccount bankAccount = this.GetAll().FirstOrDefault(element => element.Id == id);

            if (ReferenceEquals(null, bankAccount))
            {
                throw new KeyNotFoundException("The bank account with such id is not found.");
            }

            this.BonusCounter.InstallTypeBonusCounter(bankAccount.GradingVariants);

            bankAccount.Amount = bankAccount.Amount - amount;
            bankAccount.PointsForBonus = this.BonusCounter.Reduction(bankAccount.PointsForBonus);

            this.Repository.Update(bankAccount.ToAccount());
        }
    }
}