namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Contains information about the account to work with it.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Account id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of account holder.
        /// </summary>
        public string NameOwner { get; set; }

        /// <summary>
        /// Surname of account holder.
        /// </summary>
        public string SurnameOwner { get; set; }

        /// <summary>
        /// The amount on the account.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Account bonus points.
        /// </summary>
        public int PointsForBonus { get; set; }

        /// <summary>
        /// Variants of graduation of accounts.
        /// </summary>
        public int GradingVariants { get; set; }
    }
}
