using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Utilities.Exceptions
{
    public class BookStoreException : Exception
    {
        public BookStoreException()
        { }

        public BookStoreException(string message) : base(message)
        {
        }

        public BookStoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}