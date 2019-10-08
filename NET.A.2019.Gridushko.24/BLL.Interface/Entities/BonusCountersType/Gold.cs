namespace NET.A._2019.Gridushko._22
{
    public class Golden : CounterBonusType
    {
        private const int GoldCoeffCostReplenishment = 4;
        private const int GoldCoeffCostBalanse = 5;

        public Golden() : base(GoldCoeffCostReplenishment, GoldCoeffCostBalanse)
        {
        }
    }
}
