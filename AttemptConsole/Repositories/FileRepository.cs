using System;
using System.Collections.Generic;
using System.Text;

namespace AttemptConsole.Repositories
{
    public class FileRepository<T> : IRepository<T> where T : new()
    {
        public void List(T obj)
        {
        }
        public void Stat(T obj)
        {
        }
        public void Firstname(T obj)
        {
        }
        public void Lastname(T obj)
        {
        }
        public void Create(T obj)
        {
        }
        public void Edit(T obj)
        {
        }
        public void Purge(T obj)
        {
        }
        public void Exportxml(T obj)
        {
        }
        public void Exportcsv(T obj)
        {
        }
        public void Exit(T obj)
        {
            Environment.Exit(0);
        }
        public void Remove(T obj)
        {
        }
    }
}
