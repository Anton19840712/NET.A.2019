namespace Task._8._1.Repositories
{
    using Task._8._1.Repositories.Interfaces;

    public static class RepositoryFactory
    {
        public static IRepository<T> GetFileRepository<T>() where T : new()
        {
            return new FileRepository<T>();
        }
    }
}
