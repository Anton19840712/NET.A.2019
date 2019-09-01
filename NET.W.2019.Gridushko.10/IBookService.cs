namespace NET.W._2019.Gridushko._10
{

    using System.Collections.Generic;

    /// <summary>
    /// List of method operations.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Comparison by title.
        /// </summary>
        IComparer<Book> BookTitleComparer { get; }

        /// <summary>
        /// Comparison by Isbn.
        /// </summary>
        IComparer<Book> BookIsbnComparer { get; }

        /// <summary>
        /// Comparison by year.
        /// </summary>
        IComparer<Book> BookYearComparer { get; }

        /// <summary>
        /// Add <paramref name="book"/> to our storage.
        /// </summary>
        /// <param name="book">
        /// The book for adding.
        /// </param>
        /// <exception cref="BookServiceException">
        /// When any problem occures in service.
        /// </exception>
        void AddBook(Book book);

        /// <summary>
        /// This method removes a book <paramref name="book"/> from our repository.
        /// </summary>
        /// <param name="book">
        /// This book for removal.
        /// </param>
        /// <exception cref="BookServiceException">
        /// When any problem occures in service.
        /// </exception>
        void RemoveBook(Book book);

        /// <summary>
        /// This mehod finds a book in the repository by <paramref name="isbn"/> number.
        /// </summary>
        /// <param name="isbn"> ISBN book.</param>
        /// <returns>
        /// Finds a book.
        /// </returns>
        Book FindBook(string isbn);

        /// <summary>
        /// Sorts our books from the repository by IComparable
        /// </summary>
        /// <returns>
        /// Sorts our books.
        /// </returns>
        IEnumerable<Book> SortBooks(IComparer<Book> comparer);

        /// <summary>
        /// Gets all collection of our books from the repository.
        /// </summary>
        /// <returns>
        /// Books from the repository.
        /// </returns>
        /// <exception cref="BookServiceException">
        /// When any problem occures in service.
        /// </exception>
        IEnumerable<Book> GetBooks();
    }
}