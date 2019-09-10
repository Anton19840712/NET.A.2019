using System;

namespace NET.A._2019.Gridushko._15
{

    public static class Mapper
    {
        public static Account ToAccount(this BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                return null;
            }

            return new Account()
            {
                Id = bankAccount.Id,
                NameOwner = bankAccount.NameOwner,
                SurnameOwner = bankAccount.SurnameOwner,
                Amount = Convert.ToDouble(bankAccount.Amount),
                PointsForBonus = bankAccount.PointsForBonus,
                GradingVariants = bankAccount.GradingVariants
            };
        }
        public static BankAccount ToBankAccount(this Account account)
        {
            if (ReferenceEquals(account, null))
            {
                return null;
            }

            return new BankAccount()
            {
                Id = account.Id,
                NameOwner = account.NameOwner,
                SurnameOwner = account.SurnameOwner,
                Amount = Convert.ToDecimal(account.Amount),
                PointsForBonus = account.PointsForBonus,
                GradingVariants = account.GradingVariants
            };
        }
    }
}
