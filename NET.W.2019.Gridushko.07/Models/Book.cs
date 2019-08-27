namespace Task._8._1.Models
{
    using System;

    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string PublishingOffice { get; set; }
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public Decimal Cost { get; set; }

        public int CompareTo(Book other)
        {
            throw new NotImplementedException();
        }

        // TODO : implement
        public int CompareTo(Book other, Enum tag)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Book)obj);
        }

        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Isbn.Equals(other.Isbn) &&
                  this.Author.Equals(other.Author) &&
                  this.Title.Equals(other.Title) &&
                  this.PublishingOffice.Equals(other.PublishingOffice) &&
                  this.Year.Equals(other.Year) &&
                  this.PagesCount.Equals(other.PagesCount) &&
                  this.Cost.Equals(other.Cost);
        }
    }
}
