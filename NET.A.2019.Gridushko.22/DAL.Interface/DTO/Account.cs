namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Account info for working with
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Id account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Holder account name
        /// </summary>
        public string NameOwner { get; set; }

        /// <summary>
        /// Holder account surname
        /// </summary>
        public string SurnameOwner { get; set; }

        /// <summary>
        /// Account amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Account bonus point.
        /// </summary>
        public int PointsForBonus { get; set;  } 

        /// <summary>
        /// Account graduation variants
        /// </summary>
        public int GradingVariants { get; set; }
    }
}