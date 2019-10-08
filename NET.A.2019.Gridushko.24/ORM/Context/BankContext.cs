using System.Data.Entity;

namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Context to work with databse
    /// </summary>
    public class BankContext : DbContext
    {
        /// <summary>
        /// Context initialization
        /// </summary>
        public BankContext()
            : base("Bank")
        {
        }

        /// <summary>
        /// Gets accounts from the database.
        /// </summary>
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
