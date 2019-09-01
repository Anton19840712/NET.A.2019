namespace NET.W._2019.Gridushko._10
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Book class description.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        #region private field
        private string _isbn;
        private string _author;
        private string _title;
        private string _publisher;
        private string _year;
        private int _pageQuantity;
        private decimal _price;
        #endregion private field

        public Book(
            string isbn,
            string author,
            string title,
            string publisher,
            string year,
            int pageQuantity,
            decimal cost)
        {
            _isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            _year = year ?? throw new ArgumentNullException(nameof(year));
            _pageQuantity = pageQuantity;
            _price = cost;
        }

        public Book(Book book) : this(book.Isbn, book.Author, book.Title, book.Publisher, book.Year, book.pageQuantity, book.Price)
        {
        }

        public Book()
        {
        }

        /// <summary>
        /// Formats for enumeration.
        /// </summary>
        public enum ResultingFormatOutput
        {
            AT,
            ATPY,
            IATP,
            IATPYC
        }

        #region property

        /// <summary>
        /// International Standard Book Number - ISBN.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null 
        /// or an empty string or string consisting of delimiter characters.
        /// </exception>
        public string Isbn
        {
            get
            {
                return _isbn;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Null parameter or an empty string");
                }

                _isbn = value;
            }
        }

        /// <summary>
        /// Вook author.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null or an empty string.
        /// </exception>
        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null parameter or an empty string");
                }

                _author = value;
            }
        }

        /// <summary>
        /// Book title.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null or an empty string.
        /// </exception>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null parameter or an empty string");
                }

                _title = value;
            }
        }

        /// <summary>
        /// Publishing house.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null or an empty string.
        /// </exception>
        public string Publisher
        {
            get
            {
                return _publisher;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null parameter or an empty string");
                }

                _publisher = value;
            }
        }

        /// <summary>
        /// Publishing year
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the parameter <paramref name="value"/> is null or an empty string.
        /// </exception>
        public string Year
        {
            get
            {
                return _year;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null parameter or an empty string");
                }

                _year = value;
            }
        }

        /// <summary>
        /// Page quantity
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the <paramref name="value"/> argument < 0.
        /// </exception>
        public int pageQuantity
        {
            get
            {
                return _pageQuantity;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"The value of the argument{nameof(value)} must be greater than zero.");
                }

                _pageQuantity = value;
            }
        }

        /// <summary>
        /// Price of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// An exception is thrown if the <paramref name="value"/> argument is less than zero.
        /// </exception>
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"The value of the argument{nameof(value)} must be greater than zero.");
                }

                _price = value;
            }
        }

        #endregion property

        /// <summary>
        /// Comparison of two operands for equality.
        /// </summary>
        /// <param name="bookOne">The first main operand.</param>
        /// <param name="bookTwo">The second main operand.</param>
        /// <returns> True if values are equivalent and false if they are not.
        /// </returns>
        public static bool operator ==(Book bookOne, Book bookTwo)
        {
            if (ReferenceEquals(bookOne, bookTwo))
            {
                return true;
            }

            if (ReferenceEquals(null, bookOne))
            {
                return false;
            }

            return bookOne.Equals(bookTwo);
        }

        /// <summary>
        /// Comparison of two operands by inequality.
        /// </summary>
        /// <param name="bookOne">The first operand.</param>
        /// <param name="bookTwo">The second operand.</param>
        /// <returns>
        /// True if inequality, false otherwise.
        /// </returns>
        public static bool operator !=(Book bookOne, Book bookTwo)
        {
            return !(bookOne == bookTwo);
        }

        /// <summary>
        /// Checks equality of current copy of the book with <paramref name="value"/>.
        /// </summary>
        /// <param name="value"> Value for comparison</param>
        /// <returns>
        /// Returns true if objects are equivalent and false if there are not.
        /// </returns>
        public override bool Equals(object value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }

            if (ReferenceEquals(this, value))
            {
                return true;
            }

            if (value.GetType() != GetType())
            {
                return false;
            }

            return IsEqual(value as Book);
        }

        /// <summary>
        /// Checks equality of current copy of the book with <paramref name="value"/>.
        /// </summary>
        /// <param name="value"> Value for comparison</param>
        /// <returns>
        /// Returns true if objects are equivalent and false if there are not.
        /// </returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            return IsEqual(book);
        }

        /// <summary>
        /// Returns the value of hash code.
        /// </summary>
        /// <returns>
        /// Hash code value.
        /// </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns the string representation of an object.
        /// </summary>
        /// <returns>
        /// String book representation.
        /// </returns>
        public override string ToString()
        {
            return Isbn;
        }

        /// <summary>
        /// Returns the string object representation.
        /// </summary>
        /// <param name="format">Output format.</param>
        /// <returns>
        /// String representation of an book.
        /// </returns>
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return ToString();
            }

            return ToString(format, null);
        }

        /// <summary>
        ///  Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">Output format.</param>
        /// <param name="formatProvider">The provider to use to format the value.</param>
        /// <returns>
        /// String representation of an book.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(formatProvider, null))
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.Trim().ToUpper())
            {
                case nameof(ResultingFormatOutput.AT):
                    return $"{Author}, {Title}";
                case nameof(ResultingFormatOutput.ATPY):
                    return $"{Author}, {Title}, {Publisher}, {Year.ToString(formatProvider)}";
                case nameof(ResultingFormatOutput.IATP):
                    return $"ISBN 13: {Isbn}, {Author}, {Title}, {Publisher}";
                case nameof(ResultingFormatOutput.IATPYC):
                    return $"ISBN 13: {Isbn}, {Author}, {Title}, {Publisher}, {Year.ToString(formatProvider)}, " +
                        $"{string.Format(formatProvider, "{0:C}", Price)}";
                default:
                    throw new FormatException($"Unknown format - {format}");
            }
        }

        /// <summary>
        /// A comparison of the two books is case-sensitive.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <exception cref="ArgumentException">
        /// <param name="obj"> is not the same type as this instance.
        /// </exception>
        /// <returns>
        /// Less than zero. This instance before other in the sort order. 
        /// Zero. This instance exists in the same position in the
        /// sort order as other.
        /// Greater than zero. This instance after other in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (obj.GetType() != GetType())
            {
                throw new ArgumentException($"{nameof(obj)} is not the same type as this instance.", nameof(obj));
            }

            return Compare(obj as Book);
        }

        /// <summary>
        /// A comparison of the two books is case-sensitive.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns>
        /// Less than zero. This instance before other in the sort order. 
        /// Zero. This instance exists in the same position in the
        /// sort order as other.
        /// Greater than zero. This instance after other in the sort order.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return Compare(other);
        }

        private bool IsEqual(Book book)
        {
            return string.Equals(Isbn, book.Isbn, StringComparison.Ordinal);
        }

        private int Compare(Book book)
        {
            return string.Compare(Isbn, book.Isbn, ignoreCase: false);
        }
    }
}
