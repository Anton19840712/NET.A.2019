namespace NET.W._2019.Gridushko._10
{
    internal static class BookMapper
    {
        public static Book ToBook(this BookDal bookDal)
        {
            return new Book
            {
                Isbn = bookDal.Isbn,
                Author = bookDal.Author,
                Year = bookDal.Year,
                Price = bookDal.Price,
                pageQuantity = bookDal.pageQuantity,
                Publisher = bookDal.Publisher,
                Title = bookDal.Title
            };
        }
        public static BookDal ToDalBook(this Book book)
        {
            return new BookDal
            {
                Isbn = book.Isbn,
                Author = book.Author,
                Year = book.Year,
                Price = book.Price,
                pageQuantity = book.pageQuantity,
                Publisher = book.Publisher,
                Title = book.Title
            };
        }
    }
}