using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2015
{
    public class D05 : AoCPuzzle
    {
        public D05() : base(2015, 5) { }

        public override object SolvePuzzleA(string input)
        {
            return input.Split('\n').Count(IsNiceStringA);
        }

        public override object SolvePuzzleB(string input)
        {
            return input.Split('\n').Count(IsNiceStringB);
        }


        private static bool IsNiceStringB(string input)
        {
            const string regex1 = @"(..).*\1";
            const string regex2 = @"(.).\1";
            return Regex.IsMatch(input, regex1) && Regex.IsMatch(input, regex2);
        }


        private static bool IsNiceStringA(string input)
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
    }
}
