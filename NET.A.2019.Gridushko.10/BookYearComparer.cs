namespace NET.W._2019.Gridushko._10
{
    using System.Collections.Generic;
    /// <summary>
    /// Comparer, sorting by Year.
    /// </summary>
    public class BookYearComparer : IComparer<Book>
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

            return string.Compare(a.Year, b.Year, ignoreCase: false);
        }
    }
}