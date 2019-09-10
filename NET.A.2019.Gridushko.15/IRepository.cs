using System.Collections.Generic;

namespace NET.A._2019.Gridushko._15
{
    public interface IRepository
    {
        IEnumerable<Account> GetAll();
        Account Get(int id);
        void Add(Account account);
        void Update(Account account);
        void Delete(Account account);
    }
}