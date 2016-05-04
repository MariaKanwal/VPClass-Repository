using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Cryptography
{
    class Conversion
    {

        public static byte[] Conversion_To_BitMap(Image i)
        {

            //helps you read image in form of bytes
            byte[] byte_object = new byte[]
            { 
                0, 0
            };


            MemoryStream memory_stream_object = new MemoryStream();

            //Memory Stream class is used for reading the image in form of bytes and it can be used for saving the image
            //as a backstore so further work can be performed on it
            new Bitmap(i).Save(memory_stream_object, System.Drawing.Imaging.ImageFormat.Jpeg);

            //reading each byte from your memory
            byte_object = memory_stream_object.ToArray();

            //returning the converted image to load image button after conversion
            return (byte_object);
        }

    }
}
