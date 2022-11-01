using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2015
{
    public class D05 : AoCPuzzle<int>
    {
        public D05(string[] input) : base(input, 2015,5)
        {
        }

        public override int SolvePuzzleA()
        {
            int numberOfGoodStrings = 0;
            foreach (string input in Input) if (IsNiceStringA(input)) numberOfGoodStrings++;
            return numberOfGoodStrings;

        }

        public override int SolvePuzzleB()
        {
            return Input.Count(IsNiceStringB);
        }


        private bool IsNiceStringB(string input)
        {
            string regex1 = @"(..).*\1";
            string regex2 = @"(.).\1";
            return Regex.IsMatch(input, regex1) && Regex.IsMatch(input, regex2);
        }


        private bool IsNiceStringA(string input)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            if (input.Count(x => vowels.Contains(x)) < 3) return false;

            bool conditionBMet = false;
            char previousChar = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == previousChar)
                {
                    conditionBMet = true;
                    break;
                }
                else previousChar = input[i];
            }
            if (!conditionBMet) return false;

            string[] forbiddenWord = { "ab", "cd", "pq", "xy" };
            foreach (string word in forbiddenWord)
            {
                if (input.Contains(word)) return false;
            }

            return true;
        }


        private struct CharacterPair
        {
            public string PairContent;
            public int IndexAtA;
            public int IndexAtB;

            public CharacterPair(string pairContent, int indexA, int indexB)
            {
                PairContent = pairContent;
                IndexAtA = indexA;
                IndexAtB = indexB;
            }
        }





    }
}
