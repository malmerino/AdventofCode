using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStation.Utilities.Convert
{
    public static class ImagingUtilities
    {
        private static readonly ImageConverter ImageConverter = new ImageConverter();

        /// <summary>
        /// Uses ImageConverter given in <see cref="System.Drawing.Imaging"/> to convert an image to a bitmap from bytearray
        /// presumably containing a JPEG or PNG file image, into a Bitmap object, which can also be 
        /// used as an Image object.
        /// </summary>
        /// <param name="input">byte array containing JPEG or PNG file image or similar</param>
        /// <returns>Bitmap object if it works, else exception is thrown</returns>
        public static Bitmap ConvertImageFromByteArray(byte[] input)
        {
            Bitmap bm = (Bitmap)ImageConverter.ConvertFrom(input);

            if (bm != null && (Math.Abs(bm.HorizontalResolution - (int)bm.HorizontalResolution) > 0.1f ||
                               Math.Abs(bm.VerticalResolution - (int)bm.VerticalResolution) > 0.1f))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by ConvertImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                    (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        /// <summary>
        /// Convert image to ByteArray
        /// provides loss-less compression. This can be used together with the <see cref="ConvertImageFromByteArray"/>
        /// method to provide a kind of (de)serialization. 
        /// </summary>
        /// <param name="input">Image object, must be convert-able to given format</param>
        /// <param name="format">Format to turn the image to</param>
        /// <returns>byte array image of a PNG file containing the image</returns>
        public static byte[] ConvertImageToByteArray(Image input, ImageFormat format)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                input.Save(memoryStream, format);
                return memoryStream.ToArray();
            }
        }

    }
}
