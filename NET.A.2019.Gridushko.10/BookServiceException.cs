namespace NET.W._2019.Gridushko._10
{

    using System;

    /// <summary>
    /// Class contains variants of exception
    /// </summary>
    public class BookServiceException : Exception
    {
        public BookServiceException()
        {
        }

        public BookServiceException(string message) : base(message)
        {
        }

        public BookServiceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}