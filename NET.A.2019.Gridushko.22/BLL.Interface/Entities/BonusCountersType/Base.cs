namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Implements logic of a score factor Base.
    /// </summary>
    public class Base : CounterBonusType
    {
        private const int BaseCoeffCostReplenishment = 2;
        private const int BaseCoeffCostBalanse = 3;

        /// <summary>
        /// Initialization of coefficients.
        /// </summary>
        public Base() : base(BaseCoeffCostReplenishment, BaseCoeffCostBalanse)
        {
        }
    }
}