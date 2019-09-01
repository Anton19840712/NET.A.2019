namespace BooksLibrary.Formatters
{
    using NET.W._2019.Gridushko._10;
    using System;
    using System.Globalization;

    /// <summary>
    /// Class with custom formatting book
    /// </summary>
    public class BookFormatter : ICustomFormatter, IFormatProvider
    {
        /// <summary>
        /// Enumeration with available formats.
        /// </summary>
        public enum ResultingFormatOutput
        {
            AC,
            TN
        }

        /// <summary>
        /// Converts the value of an object to a string representation
        /// </summary>
        /// <param name="format"> Format string contains formats specificity.</param>
        /// <param name="arg"> An object for format.</param>
        /// <param name="formatProvider"> Object enables information about current instance.</param>
        /// <returns>
        /// The representation of string of the value, formatted as specified by format and formatProvider.
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                return null;
            }

            var book = arg as Book;

            if (ReferenceEquals(book, null))
            {
                return null;
            }

            if (ReferenceEquals(formatProvider, null))
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.Trim().ToUpper())
            {
                case nameof(ResultingFormatOutput.AC):
                    return $"{book.Author}, {string.Format(formatProvider, "{0:C}", book.Price)}";
                case nameof(ResultingFormatOutput.TN):
                    return $"{book.Title}, {book.pageQuantity}";
                default:
                    throw new FormatException($"Unknown format - {format}");
            }
        }

        /// <summary>
        /// Returns an object? that enables formatting services for the specific type.
        /// </summary>
        /// <param name="formatType">An object specifies the type of format object.</param>
        /// <returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}