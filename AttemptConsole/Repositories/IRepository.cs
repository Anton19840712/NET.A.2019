using System;
using System.Collections.Generic;
using System.Text;

namespace AttemptConsole.Repositories
{
    public interface IRepository<T>
    {
        void Create(T obj);
        void Remove(T obj);
        void Edit(T obj);
        void Purge(T obj);
    }
 }
