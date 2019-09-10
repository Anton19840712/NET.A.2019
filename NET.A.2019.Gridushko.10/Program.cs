namespace NET.W._2019.Gridushko._10

{
    using System;
    using System.Collections.Generic;
    using BooksLibrary.Formatters;
    using BookStorage;
    //using Logger;
    public class Program
    {
        private static readonly string FilePath = @"data.bin";
        private static ILogger _logger;
        public static void Main()
        {
            _logger = LoggerCreater.GetLogger(nameof(Program));
            try
            {
                IBookStorage bookRepository = new BookBinaryStorage(FilePath);
                IBookService bookService = new BookListService(bookRepository);

                Console.WriteLine("AddTest");
                Console.WriteLine(new string('-', 100));
                AddTest(bookService);

                Console.WriteLine("FindTest");
                FindTest(bookService);

                Console.WriteLine("DeleteTest");
                DeleteTest(bookService);

                Console.WriteLine("SortTest");
                SortTest(bookService);

                Console.WriteLine("FormatTest");
                FormatTest(bookService);

                Console.WriteLine("FormatExtensionTest");
                FormatExtensionTest(bookService);

                var books = bookService.GetBooks();
                foreach (var book in books)
                {
                    bookService.RemoveBook(book);
                }

                bookService.AddBook(new Book("ISBN7", "Author1", "Title - 5", "Publisher 1", "2020", 130, 5m));
            }
            catch (Exception e)
            {
                _logger.Error("Error, see nuances", e);
            }

            Console.ReadLine();
        }

        private static void ShowBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(string.Format($"ISBN: {book.Isbn,30} Title: {book.Title,20} Author: {book.Author}"), book);
            }

            Console.WriteLine(new string('-', 100));
        }

        private static void ShowBooks(params Book[] books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(string.Format($"ISBN: {book.Isbn,30} Title: {book.Title,20} Author: {book.Author}"), book);
            }

            Console.WriteLine(new string('-', 80));
        }

        private static void AddTest(IBookService service)
        {
            var book1 = new Book("978-5-17-080115-2", "Джефри Рихтер", "CLR", "АСТ", "2015", 320, 10m);
            var book2 = new Book("978-5-389-04564-4", "Оскар Уайльд", "Весна", "Азбука", "2019", 416, 9m);
            var book3 = new Book("ISBN3", "Author3", "Title3", "Publisher 3", "2020", 170, 3m);
            var book6 = new Book("ISBN6", "Author6", "Title6", "Publisher 6", "2020", 170, 3m);

            var bookList = new List<Book>() { book1, book2, book3, book6};

            foreach (var book in bookList)
            {
                service.AddBook(book);
                ShowBooks(service.GetBooks());
            }
        }

        private static void FindTest(IBookService service)
        {
            string isbn3 = "ISBN3";
            string isbn6 = "ISBN6";

            ShowBooks(service.FindBook(isbn3));
            if (service.FindBook(isbn6) == null)
            {
                Console.WriteLine("The book was not found.");
                Console.WriteLine(new string('-', 100));
            }
        }

        private static void DeleteTest(IBookService service)
        {
            string isbn3 = "ISBN3";

            Console.WriteLine("Before");
            ShowBooks(service.GetBooks());

            service.RemoveBook(service.FindBook(isbn3));

            Console.WriteLine("After");
            ShowBooks(service.GetBooks());
        }

        private static void SortTest(IBookService service)
        {
            ShowBooks(service.SortBooks(service.BookTitleComparer));
        }

        private static void FormatTest(IBookService service)
        {
            var books = service.GetBooks();

            foreach (var book in books)
            {
                Console.WriteLine(book.ToString(Book.ResultingFormatOutput.AT.ToString()));
            }

            foreach (var book in books)
            {
                Console.WriteLine(book.ToString(Book.ResultingFormatOutput.ATPY.ToString()));
            }

            foreach (var book in books)
            {
                Console.WriteLine(book.ToString(Book.ResultingFormatOutput.IATP.ToString()));
            }

            foreach (var book in books)
            {
                Console.WriteLine(book.ToString(Book.ResultingFormatOutput.IATPYC.ToString()));
            }

            Console.WriteLine(new string('-', 100));
        }

        private static void FormatExtensionTest(IBookService service)
        {
            var books = service.GetBooks();

            foreach (var book in books)
            {
                Console.WriteLine(string.Format(new BookFormatter(), "{0:AC}", book));
            }

            foreach (var book in books)
            {
                Console.WriteLine(string.Format(new BookFormatter(), "{0:TN}", book));
            }

            Console.WriteLine(new string('-', 100));
        }
    }
}