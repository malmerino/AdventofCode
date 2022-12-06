using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2022
{
    public class D06 : AoCPuzzle
    {
        public D06() : base(2022, 06) { }

        public override object SolvePuzzleA(string input)
        {
            return FindDistinctCharacters(4, input);
        }

        public override object SolvePuzzleB(string input)
        {
            return FindDistinctCharacters(14, input);
        }


        private int FindDistinctCharacters(int distinct, string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string msg = input[i..(i + distinct)];

                if (msg.GroupBy(x => x).Count() == distinct)
                {
                    return i + distinct;
                }
            }
            throw new Exception($"{distinct} distinct characters could not be found");
        }
    }
}

