using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.ImageHelpers
{
    internal class ImageCodec
    {
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }
    }
}
