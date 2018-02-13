using ImageEditor.Operations.Formats;
using ImageEditor.Operations.Resizer;
using ImageEditor.ThrowExceptions;
using ImageEditor.Tools;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageEditor
{
    public class Image
    {
      
        private Tools.Convert converter;

       
        private Resize resizer;

       
        public void Convert(string sourcePath, string destinationPath, ConvertType type)
        {
            switch (type)
            {
                case ConvertType.Jpg:
                    converter = new Tools.Convert(new Jpg());
                    break;

                case ConvertType.Png:
                    converter = new Tools.Convert(new Png());
                    break;

                case ConvertType.Gif:
                    converter = new Tools.Convert(new Gif());
                    break;
            }

            try
            {
                converter.Converter(sourcePath, destinationPath);
            }
            catch (ArgumentException)
            {
                throw new ImageNullOrEmptyException("Null or empty image path");
            }
            catch (FileNotFoundException)
            {
                throw new ImageNotFoundException("Image not found");
            }
            catch (OutOfMemoryException)
            {
                throw new InvalidImageException("Invalid image");
            }
            catch (NotSupportedException)
            {
                throw new InvalidImageException("Invalid image");
            }
            catch (ImageAlreadyExistsException ex)
            {
                throw new ImageAlreadyExistsException("Image with this name already exists", ex);
            }
            catch (ExternalException ee)
            {
                throw new ExternalException("External error", ee);
            }
        }

       
        public void Resize(string sourcePath, string destinationPath, ResizeType type, int width, int height, int x = 0, int y = 0)
        {
            switch (type)
            {
                case ResizeType.Crop:
                    resizer = new Resize(new Crop(x, y));
                    break;
                case ResizeType.Skew:
                    resizer = new Resize(new Skew());
                    break;
            }

            try
            {
                resizer.Resizer(sourcePath, destinationPath, width, height);
            }
            catch (ArgumentException)
            {
                throw new ImageNullOrEmptyException("Empty path");
            }
            catch (FileNotFoundException)
            {
                throw new ImageNotFoundException("Image can not be found");
            }
            catch (OutOfMemoryException)
            {
                throw new InvalidImageException("Invalid image or invalid dimensions");
            }
            catch (InvalidImageDimensionsException iid)
            {
                throw new InvalidImageDimensionsException("Invalid image dimensions", iid);
            }
          
            
            catch (ImageAlreadyExistsException ex)
            {
                throw new ImageAlreadyExistsException("Image with this name already exists", ex);
            }
            catch (ExternalException ee)
            {
                throw new ExternalException("External error", ee);
            }
        }
    }

    public enum ConvertType
    {
        Jpg,
        Png,
        Gif
    }

    public enum ResizeType
    {
        Crop,
        Skew
    }
}
