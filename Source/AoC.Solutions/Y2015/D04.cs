using System.Text;
using SpaceStation.Utilities.Cryptography;

namespace AoC.Solutions.Y2015
{
    public class D04 : AoCPuzzle
    {
        public D04() : base(2015, 4) { }

        public override object SolvePuzzleA(string input)
        {
            return FindHashStartingWith("00000", input);

        }

        public override object SolvePuzzleB(string input)
        {
            return FindHashStartingWith("000000", input);
        }


        private static int FindHashStartingWith(string startWith, string input)
        {
            int index = 0;
            while (true)
            {
                string result = Hashing.CalculateHash(input + index, Hashing.HashAlgorithm.MD5);

                if (result.StartsWith(startWith))
                {
                    return index;
                }
                else index++;
            }
        }
    }
}
