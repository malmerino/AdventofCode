using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStation.Convert
{
    public static class ByteArrayUtils
    {
        public static string ByteArrayToBase64(byte[] input)
        {
            return System.Convert.ToBase64String(input);
        }

        public static byte[] Base64ToByteArray(string base64String)
        {
            return System.Convert.FromBase64String(base64String);
        }

    }
}
