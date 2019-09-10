namespace NET.A._2019.Gridushko._15.BLL.Interface.Interfaces
{
    public interface IBonusCounter
    {
        void InstallTypeBonusCounter(GradingVariant gradingType);
        int Increase(int bonusPoints);
        int Reduction(int bonusPoints);
    }
}