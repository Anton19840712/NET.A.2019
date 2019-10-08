using System;
namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Provides method for getting a bonus counter.
    /// </summary>
    public class BonusCounterFactory
    {
        /// <summary>
        /// Returns a variant of counter
        /// </summary>
        public static CounterBonusType GetBonusCounter(GradingVariant gradingType)
        {
            switch (gradingType)
            {
                case GradingVariant.Base:
                    {
                        return new Base();
                    }

                case GradingVariant.Golden:
                    {
                        return new Golden();
                    }

                case GradingVariant.Platinus:
                    {
                        return new Platinus();
                    }

                default:
                    {
                    }
            }
        }
    }
}