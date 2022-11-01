using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AoC.Y2015
{
    internal class D04 : AoCPuzzle
    {
        public D04(string[] input) : base(input)
        {
        }

        public override int SolvePuzzleA()
        {
            int index = 0;
            while (true)
            {
                string result = Md5Hash(GetInputAsString + index);

                if (result.StartsWith("00000"))
                {
                    return index;
                }
                else index++;
            }
        }

        public override int SolvePuzzleB()
        {
            int index = 0;
            while (true)
            {
                string result = Md5Hash(GetInputAsString + index);

                if (result.StartsWith("000000"))
                {
                    return index;
                }
                else index++;
            }
        }

        private string Md5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
