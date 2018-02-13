using ImageEditor.Operations.Formats;
using ImageEditor.ThrowExceptions;
using System.IO;

namespace ImageEditor.Tools
{
    class Convert
    {
        private IConvertableFormat convertFormat;

        public Convert(IConvertableFormat convertFormat)
        {
            this.convertFormat = convertFormat;
        }

        public void Converter(string sourcePath, string destinationPath)
        {
            if (File.Exists(destinationPath))
            {
                throw new ImageAlreadyExistsException();
            }

            this.convertFormat.Convert(sourcePath, destinationPath);
        }
    }
}
