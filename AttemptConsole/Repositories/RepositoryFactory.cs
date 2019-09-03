using System;
using System.Collections.Generic;
using System.Text;

namespace AttemptConsole.Repositories
{
    public static class RepositoryFactory
    {
        public static IRepository<T> GetFileRepository<T>() where T : new()
        {
            return new FileRepository<T>();
        }
    }
}
