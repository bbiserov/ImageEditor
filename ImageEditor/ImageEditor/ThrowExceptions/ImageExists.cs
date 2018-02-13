using System;

namespace ImageEditor.ThrowExceptions
{
    public class ImageAlreadyExistsException : Exception
    {
        public ImageAlreadyExistsException()
        {
        }

        public ImageAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
