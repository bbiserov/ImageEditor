using ImageEditor.Operations.Resizer;
using ImageEditor.ThrowExceptions;
using System.IO;

namespace ImageEditor.Tools
{
    class Resize
    {
        private IResizable resizeModule;

        public Resize(IResizable resizeModule)
        {
            this.resizeModule = resizeModule;
        }

        public void Resizer(string sourcePath, string destinationPath, int width, int height)
        {
            if (File.Exists(destinationPath))
            {
                throw new ImageAlreadyExistsException();
            }

            if (width <= 0 || height <= 0)
            {
                throw new InvalidImageDimensionsException();
            }

            this.resizeModule.Resize(sourcePath, destinationPath, width, height);
        }
    }
}
