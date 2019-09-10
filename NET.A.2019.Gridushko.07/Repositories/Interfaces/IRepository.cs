namespace Task._8._1.Repositories.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        void Add(T obj);

        void Remove(T obj);

        List<T> GetAll();
    }
}
