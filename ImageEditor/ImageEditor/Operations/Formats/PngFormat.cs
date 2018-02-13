using ImageEditor.ImageHelpers;
using System.Drawing.Imaging;

namespace ImageEditor.Operations.Formats
{
    internal class Png : IConvertableFormat
    {
        public void Convert(string sourcePath, string destinationPath)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(sourcePath))
            {
                var qualityParam = new EncoderParameter(Encoder.Quality, 100L);
                var pngCodec = ImageCodec.GetEncoderInfo("image/png");

                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                image.Save(destinationPath, pngCodec, encoderParams);
            }
        }
    }
}
