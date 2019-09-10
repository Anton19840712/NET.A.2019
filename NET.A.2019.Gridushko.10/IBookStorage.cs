namespace BookStorage
{
    using NET.W._2019.Gridushko._10;
    using System.Collections.Generic;

    /// <summary>
    /// Interface with methods to interract with the repository.
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Gets all books from the repository.
        /// </summary>
        /// <exception cref="BookStorageException">
        /// </exception>
        /// <returns>
        /// Books in the current repository.
        /// </returns>
        IEnumerable<BookDal> GetBooks();

        /// <summary>
        /// Inserts books in our repository.
        /// </summary>
        /// <param name="books">
        /// </param>
        /// <exception cref="BookStorageException">
        /// </exception>
        void SetBooks(IEnumerable<BookDal> books);
    }
}