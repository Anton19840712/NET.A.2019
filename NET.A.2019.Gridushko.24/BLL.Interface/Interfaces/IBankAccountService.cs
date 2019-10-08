namespace NET.A._2019.Gridushko._22
{
    public interface IBankAccountService
    {
        /// <summary>
        /// To get a list of objects.
        /// </summary>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Enables a new bank account.
        /// </summary>
        void Open(string nameOwner, string ownerSurname, double amount, GradingVariant gradingType);

        /// <summary>
        /// Disables a bank account.
        /// </summary>
        void Close(int id);

        void Refill(int id, double amount);

        /// <summary>
        /// Withdrawes from the bank account.
        /// </summary>
        void Withdraw(int id, double amount);        
    }
}