using System;
using System.Collections.Generic;
using System.Text;

namespace AttemptConsole.Repositories
{
    public interface IRepository<T>
    {
        void Stat(T obj);
        void Firstname(T obj);
        void Lastname(T obj);
        void Create(T obj);
        void Remove(T obj);
        void Edit(T obj);
        void Purge(T obj);
        void Exportxml(T obj);
        void Exportcsv(T obj);
        void Exit(T obj);
    }
 }
