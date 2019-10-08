namespace NET.A._2019.Gridushko._22
{
    public class Platinus : CounterBonusType
    {
        private const int PlatinumCoeffCostReplenishment = 6;
        private const int PlatinumCoeffCostBalanse = 7;

        public Platinus() : base(PlatinumCoeffCostReplenishment, PlatinumCoeffCostBalanse)
        {
        }
    }
}
