using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming
#pragma warning disable CS0618

namespace SpaceStation.Cryptography
{
    public static class Hashing
    {
        public enum HashAlgorithm
        {
            [Obsolete("MD5 is very outdated and should not be used for any security purposes", false)]
            MD5,
            SHA512

        }


        public static string CalculateHash(string input, HashAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HashAlgorithm.MD5: return CalculateMd5(input);
                case HashAlgorithm.SHA512: return CalculateSha512(input);
                default: return "";
            }
        }


        private static string CalculateMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return hashBytes.ByteToX2String();
            }
        }

        private static string CalculateSha512(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = sha512.ComputeHash(inputBytes);

                return hashBytes.ByteToX2String();
            }
        }



        private static string ByteToX2String(this byte[] input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte t in input)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
