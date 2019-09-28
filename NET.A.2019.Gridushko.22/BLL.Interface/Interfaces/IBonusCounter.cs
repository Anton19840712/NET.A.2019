namespace NET.A._2019.Gridushko._22

{
    /// <summary>
    /// For bonuses calculation.
    /// </summary>
    public interface IBonusCounter
    {
        void InstallTypeBonusCounter(GradingVariant gradingType);

        /// <summary>
        /// For increasing points of bonus.
        /// </summary>
        int Increase(int bonusPoints);

        /// <summary>
        /// For reductions points of bonus.
        /// </summary>
        int Reduction(int bonusPoints);
    }
}