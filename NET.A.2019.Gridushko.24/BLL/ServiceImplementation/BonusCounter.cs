using System;

namespace NET.A._2019.Gridushko._22
{
    public class BonusCounter : IBonusCounter
    {
        private CounterBonusType bonusCounter;

        /// <summary>
        /// Inintialization of bonusCounter
        /// </summary>
        public BonusCounter()
        {
            bonusCounter = null;
        }
        /// <summary>
        /// Counter installation
        /// </summary>
        public void InstallTypeBonusCounter(GradingVariant gradingType)
        {
            this.bonusCounter = BonusCounterFactory.GetBonusCounter(gradingType);
        }

        /// <summary>
        /// Method to increase bonuses
        /// </summary>
        public virtual int Increase(int bonusPoints)
        {
            return bonusPoints + this.bonusCounter.CoeffCostReplenishment;
        }

        /// <summary>
        /// Method to reduce bonuses
        /// </summary>
        public virtual int Reduction(int bonusPoints)
        {
            return (bonusPoints <= this.bonusCounter.CoeffCostReplenishment)
                ? 0
                : bonusPoints - this.bonusCounter.CoeffCostReplenishment;
        }
    }
}
