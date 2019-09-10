namespace NET.W._2019.Gridushko._10
{
    using System.Collections.Generic;

    /// <summary>
    /// Isbn comparison
    /// </summary>
    public class BookIsbnComparer : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (ReferenceEquals(null, b))
            {
                return 1;
            }

            if (ReferenceEquals(a, b))
            {
                return 0;
            }

            return string.Compare(a.Isbn, b.Isbn, ignoreCase: false);
        }
    }
}