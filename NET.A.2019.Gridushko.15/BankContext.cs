namespace NET.A._2019.Gridushko._15
{
    public class BankContext : DbContext
    {
        public BankContext()
            : base("Bank")
        {
        }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
