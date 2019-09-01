namespace NET.W._2019.Gridushko._10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookStorage;


    /// <summary>
    /// Interface implemetation<see cref="IBookService"/>
    /// </summary>
    public class BookListService : IBookService
    {
        #region private field
        private IBookStorage _bookStorage;
        private List<Book> _books = new List<Book>();
        #endregion private field

        /// <summary>
        /// Adding the instance of service
        /// </summary>
        /// <param name="bookStorage">Book storage.</param>

        public BookListService(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage ?? throw new ArgumentNullException(nameof(bookStorage));

            try
            {
                _books.AddRange(_bookStorage.GetBooks().Select(bookDal => bookDal.ToBook()));
            }
            catch (BookStorageException e)
            {
                throw new BookServiceException("An error occurred while reading from the repository.", e);
            }

        }

        /// <summary>
        /// Comparison by Title.
        /// </summary>
        public IComparer<Book> BookTitleComparer { get; } = new BookTitleComparer();

        /// <summary>
        /// Comparison by Year.
        /// </summary>
        public IComparer<Book> BookYearComparer { get; } = new BookYearComparer();

        /// <summary>
        /// Comparison by Isbn.
        /// </summary>
        public IComparer<Book> BookIsbnComparer { get; } = new BookIsbnComparer();

        /// <summary>
        /// Add <paramref name="book"/> to the storage.
        /// </summary>
        /// <param name="book">
        /// The book to add to the repository.
        /// </param>
        /// <exception cref="BookServiceException">
        /// Throws exception when problems in bookservice detected.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="book"/> is passed.
        /// </exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            bool presenceInTheRepository = false;

            foreach (var bookItem in _books)
            {
                if (bookItem == book)
                {
                    presenceInTheRepository = true;
                    break;
                }
            }

            if (!presenceInTheRepository)
            {
                _books.Add(book);
                try
                {
                    _bookStorage.SetBooks(_books.Select(bookModel => bookModel.ToDalBook()));
                }
                catch (BookStorageException e)
                {
                    _books.Remove(book);
                    throw new BookServiceException("An error occurred while writing to the repository.", e);
                }
            }
            else
            {
                throw new BookServiceException("The book is already in the repository.");
            }
        }

        /// <summary>
        /// Finds the book in the repository by <paramref name="isbn"/> ISBN.
        /// </summary>
        /// <param name="isbn"> ISBN book.</param>
        /// <exception cref="ArgumentNullException">
        /// Exception when was passed a null argument <paramref name="isbn"/>.
        /// </exception>
        /// <exception cref="BookServiceException">
        /// Exception whrn service problems.
        /// </exception>
        /// <returns>
        /// Method finds  a book.
        /// if it's not there null
        /// </returns>
        public Book FindBook(string isbn)
        {
            Book resultBook = null;

            if (isbn == null)
            {
                throw new ArgumentNullException(nameof(isbn));
            }

            foreach (var book in _books)
            {
                if (book.Isbn == isbn)
                {
                    resultBook = new Book(book);
                    break;
                }
            }

            return resultBook;
        }

        /// <summary>
        /// Gets all books from collection in repository.
        /// </summary>
        /// <returns>
        /// Books from the repository.
        /// </returns>
        public IEnumerable<Book> GetBooks()
        {
            return _books.ToArray();
        }

        /// <summary>
        /// Method removes a concrete book <paramref name="book"/> from collection.
        /// </summary>
        /// <param name="book">
        /// The book for removal.
        /// </param>
        /// <exception cref="BookServiceException">
        /// When problems occure in service.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception that is thrown when a null argument <paramref name="isbn"/> is passed.
        /// </exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (_books.Remove(book))
            {
                try
                {
                    _bookStorage.SetBooks(_books.Select(bookModel => bookModel.ToDalBook()));
                }
                catch (BookStorageException e)
                {
                    _books.Add(book);
                    throw new BookServiceException("An error occurred while writing to the repository.", e);
                }
            }
            else
            {
                throw new BookServiceException("The book for deletion was not found.");
            }
        }

        /// <summary>
        /// Sorts books from the repository by IComparable
        /// </summary>
        /// <returns>
        /// Sorts books.
        /// </returns>
        public IEnumerable<Book> SortBooks(IComparer<Book> comparable)
        {
            var books = new List<Book>(_books);
            books.Sort(comparable);
            return books.ToArray();
        }
    }
}