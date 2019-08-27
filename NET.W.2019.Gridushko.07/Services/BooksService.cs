namespace Task._8._1.Services
{
    using System.Collections.Generic;

    using Task._8._1.Models;
    using Task._8._1.Repositories;
    using Task._8._1.Repositories.Interfaces;

    public class BooksService
    {
        private readonly IRepository<Book> repository = RepositoryFactory.GetFileRepository<Book>();

        private static BooksService instance;

        public static BooksService Instance => BooksService.instance ?? (BooksService.instance = new BooksService());

        public void AddBook(Book book)
        {
            this.repository.Add(book);
        }

        public void RemoveBook(Book book)
        {
            this.repository.Remove(book);
        }

        public void FindBookByTag(string tagName)
        {

        }

        public List<Book> GetAll()
        {
            return this.repository.GetAll();
        }

    }
}
