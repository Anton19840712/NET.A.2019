using System;

namespace NET.A._2019.Gridushko._15
{

    /// <summary>
    /// Implements an adapter for the account.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Represent <paramref name="bankAccount"/> as an object of Account type.
        /// </summary>
        /// <param name="account">The object of BankAccount type.</param>
        /// <returns>The object of Account type.</returns>
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

        /// <summary>
        /// Represent <paramref name="account"/> as an object of BankAccount type.
        /// </summary>
        /// <param name="account">The object of Account type.</param>
        /// <returns>The object of BankAccount type.</returns>
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
