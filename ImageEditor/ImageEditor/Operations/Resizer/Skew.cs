using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageEditor.Operations.Resizer
{
    class Skew : IResizable
    {
        public void Resize(string sourcePath, string destinationPath, int width, int height)
        {
            using (Bitmap imageFromFile = new Bitmap(System.Drawing.Image.FromFile(sourcePath)))
            {
                using (Bitmap image = new Bitmap(width, height))
                {
                    using (Graphics graphic = Graphics.FromImage(image))
                    {
                        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphic.SmoothingMode = SmoothingMode.HighQuality;
                        graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphic.CompositingQuality = CompositingQuality.HighQuality;
                        graphic.DrawImage(imageFromFile, 0, 0, width, height);
                    }

                    image.Save(destinationPath);
                }                
            }
        }
    }
}
