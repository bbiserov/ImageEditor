using System;

namespace ImageEditor.ThrowExceptions
{
    public class InvalidImageDimensionsException : Exception
    {
        public InvalidImageDimensionsException()
        {
        }

        public InvalidImageDimensionsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
