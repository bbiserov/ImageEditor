using System;

namespace ImageEditor.ThrowExceptions
{
    public class ImageNotFoundException : Exception
    {
        public ImageNotFoundException(string message) : base(message)
        {
        }
    }
}
