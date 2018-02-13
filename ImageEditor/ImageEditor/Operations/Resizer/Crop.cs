using ImageEditor.ThrowExceptions;
using System.Drawing;

namespace ImageEditor.Operations.Resizer
{
    class Crop : IResizable
    {
        private int x;
        private int y;

        public Crop(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new InvalidImageDimensionsException();
            }

            this.x = x;
            this.y = y;
        }

        public void Resize(string sourcePath, string destinationPath, int width, int height)
        {
            using (Bitmap bitmapImage = new Bitmap(System.Drawing.Image.FromFile(sourcePath)))
            {
                if (x > bitmapImage.Width || y > bitmapImage.Height ||
                    width + x > bitmapImage.Width || height + y > bitmapImage.Height)
                {
                    throw new InvalidImageDimensionsException();
                }

                Rectangle rectangle = new Rectangle(x, y, width, height);

                using (Bitmap croppedImage = bitmapImage.Clone(rectangle, bitmapImage.PixelFormat))
                {
                    croppedImage.Save(destinationPath);
                }
            }    
        }
    }
}
