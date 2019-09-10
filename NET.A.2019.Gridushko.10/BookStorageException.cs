namespace NET.W._2019.Gridushko._10

{
    using System;

    /// <summary>
    /// Class contains variants of exception
    /// </summary>
    public class BookStorageException : Exception
    {
        public BookStorageException()
        {
        }

        public BookStorageException(string message) : base(message)
        {
        }

        public BookStorageException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}