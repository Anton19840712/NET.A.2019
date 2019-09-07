using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._13
{
    public class BookTestingClass : IComparable<BookTestingClass>
    {
        public int Cost { get; }

        public BookTestingClass(int cost)
        {
            Cost = cost;
        }

        public int CompareTo(BookTestingClass other)
        {
            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            return Cost.CompareTo(other.Cost);
        }

        public override bool Equals(object obj)
        {
            BookTestingClass book = obj as BookTestingClass;
            return Equals(book);
        }

        public bool Equals(BookTestingClass other)
        {
            return Cost.Equals(other.Cost);
        }

    }
}

