using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Operations.Formats
{
    interface IConvertableFormat
    {
        void Convert(string sourcePath, string destinationPath);
    }
}
