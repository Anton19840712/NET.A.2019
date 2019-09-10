namespace NET.A._2019.Gridushko._15
{
    public static class BankAccountMapper
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
                Amount = bankAccount.Amount,
                PointsForBonus = bankAccount.PointsForBonus,
                GradingVariants = (int)bankAccount.GradingVariants
            };
        }
        public static BankAccount ToBankAccount(this Account account)
        {
            if (ReferenceEquals(account, null))
            {
                return null;
            }
            return new BankAccount(
                account.Id,
                account.NameOwner,
                account.SurnameOwner,
                account.Amount,
                account.PointsForBonus,
                (GradingVariant)account.GradingVariants);
        }
    }
}