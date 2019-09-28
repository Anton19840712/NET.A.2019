using System.Collections.Generic;

namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Enables data from account
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// List of objects
        /// </summary>
        IEnumerable<Account> GetAll();

        /// <summary>
        /// Gets any one object by id.
        /// </summary>
        Account Get(int id);

        /// <summary>
        /// Creates object in storage.
        /// </summary>
        void Add(Account account);

        /// <summary>
        /// Edits the data about the object.
        /// </summary>
        void Edit(Account account);

        /// <summary>
        /// Removes the data about the object.
        /// </summary>
        void Delete(Account account);
    }
}