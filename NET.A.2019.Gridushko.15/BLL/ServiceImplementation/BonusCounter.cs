using System;

namespace NET.A._2019.Gridushko._15
{
    public class BonusCounter : IBonusCounter
    {
        private BonusCounterType bonusCounter;
        public BonusCounter()
        {
            bonusCounter = null;
        }
        public void InstallTypeBonusCounter(GradingVariant gradingType)
        {
            this.bonusCounter = BonusCounterFactory.GetBonusCounter(gradingType);
        }
        public virtual int Increase(int bonusPoints)
        {
            if (ReferenceEquals(null, bonusCounter))
            {
                throw new InvalidOperationException("The type of bonus counter is not install.");
            }

            return bonusPoints + this.bonusCounter.CoeffCostReplenishment;
        }
        public virtual int Reduction(int bonusPoints)
        {
            if (ReferenceEquals(null, bonusCounter))
            {
                throw new InvalidOperationException("The type of bonus counter is not install.");
            }

            return (bonusPoints <= this.bonusCounter.CoeffCostReplenishment)
                ? 0
                : bonusPoints - this.bonusCounter.CoeffCostReplenishment;
        }
    }
}
