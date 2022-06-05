using System;
using System.Drawing;
using System.IO;

namespace scratch_collect.Desktop.Utilities
{
    public class ImageHelper
    {
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();

            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static Bitmap ByteToImage(byte[] byteArrayIn)
        {
            return new Bitmap(new MemoryStream(byteArrayIn));
        }
    }
}