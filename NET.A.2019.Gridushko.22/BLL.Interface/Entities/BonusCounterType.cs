namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Class for bonus counter.
    /// </summary>
    public abstract class CounterBonusType
    { 
        /// <summary>
        /// Constructor to initialize the coefficients.
        /// </summary>
        public CounterBonusType(int costReplenishmentCoef, int costBalanseCoeff)
        {
            this.CoeffCostReplenishment = costReplenishmentCoef;
            this.CoeffCostBalanse = costBalanseCoeff;
        }

        public int CoeffCostReplenishment { get; private set; }

        /// <summary>
        /// For debiting operations in account.
        /// </summary>
        public int CoeffCostBalanse { get; private set; }
    }
}