using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._08
{
    public abstract class AccountsSortingGrades
    {
        protected readonly int CoefficientCostRefill ;
        protected readonly int CoefficientCostBalance;

        /// <summary>
        /// Full constructor to initialize the coefficients.
        /// </summary>
        /// <param name="coefficientCostRefill ">The coefficient of replenishment used in the replenishment of the account.</param>
        /// <param name="coefficientCostAccountBalance">The balance cost factor used when debiting an account.</param>
        public AccountsSortingGrades(int coefficientCostRefill , int coefficientCostAccountBalance)
        {
            CoefficientCostRefill  = coefficientCostRefill ;
            CoefficientCostBalance = coefficientCostAccountBalance;
        }

        /// <summary>
        /// Increases bonus points depending on the coefficient of replenishment.
        /// </summary>
        /// <param name="bonusSpecialPoints">Existing bonus points.</param>
        /// <returns>Increased bonus points.</returns>
        public virtual int IncreaseBonusPoints(int bonusSpecialPoints)
        {
            return bonusSpecialPoints + CoefficientCostRefill;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        /// <param name="bonusSpecialPoints">Existing bonus points.</param>
        /// <returns>Reduced bonus points.</returns>
        public virtual int ReductionBonusPoints(int bonusSpecialPoints)
        {
            return (bonusSpecialPoints <= CoefficientCostRefill )
                ? 0
                : bonusSpecialPoints - CoefficientCostRefill ;
        }
    }
}