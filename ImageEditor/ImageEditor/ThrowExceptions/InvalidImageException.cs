using System;

namespace ImageEditor.ThrowExceptions
{
    public class InvalidImageException : Exception
    {
        public InvalidImageException(string message) : base(message)
        {
        }
    }
}
