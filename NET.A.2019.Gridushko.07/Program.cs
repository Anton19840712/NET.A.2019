namespace Task._8._1
{
    using System;
    using Task._8._1.Models;
    using Task._8._1.Services;
    class Program
    {
        static void Main(string[] args)
        {
            BooksService.Instance.AddBook(new Book
            {
                Isbn = "978-5-4461-1102-2",
                Author = "Джеффри Рихтер",
                Title = "CLR via c#",
                PublishingOffice = "Питер",
                Year = 2019,
                PagesCount = 896,
                Cost = 200
            });

            Console.WriteLine(BooksService.Instance.GetAll()[0].Isbn);
            Console.WriteLine(BooksService.Instance.GetAll()[0].Author);
            Console.WriteLine(BooksService.Instance.GetAll()[0].Title);
            Console.WriteLine(BooksService.Instance.GetAll()[0].PublishingOffice);
            Console.WriteLine(BooksService.Instance.GetAll()[0].Year);
            Console.WriteLine(BooksService.Instance.GetAll()[0].PagesCount);
            Console.WriteLine(BooksService.Instance.GetAll()[0].Cost);
            Console.ReadLine();
        }
    }
}
