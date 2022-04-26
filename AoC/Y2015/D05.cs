using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y2015
{
    internal class D05 : AoCPuzzle
    {
        public D05(string[] input) : base(input)
        {
        }

        public override int SolvePuzzleA()
        {
            int numberOfGoodStrings = 0;
            foreach (var input in Input) if (IsNiceStringA(input)) numberOfGoodStrings++;
            return numberOfGoodStrings;

        }

        public override int SolvePuzzleB()
        {
            int numberOfGoodStrings = 0;
            foreach (var input in Input) if (IsNiceStringB(input)) numberOfGoodStrings++;
            return numberOfGoodStrings;
        }


        private bool IsNiceStringB(string input)
        {
            List<CharacterPair> possiblePairs = new List<CharacterPair>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                bool proceed = true;

                if (possiblePairs.Any(x => x.PairContent == "" + input[i] + input[i + 1]))
                {
                    foreach (var item in possiblePairs.Where(x => x.PairContent == $"{input[i]}{input[i + 1]}"))
                    {
                        if (item.IndexAtA == i || item.IndexAtB == i)
                        {
                            proceed = false;
                            break;
                        }
                    }
                }
                if (proceed)
                    possiblePairs.Add(new CharacterPair("" + input[i] + input[i + 1], i, i + 1));
            }

            if (possiblePairs.GroupBy(x => x.PairContent).Where(g => g.Count() > 1).Count() < 1) return false;

            bool conditionBMet = false;
            char previousCharB = input[0];
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i + 1] == previousCharB && input[i + 1] != input[i])
                {
                    conditionBMet = true;
                }
                else previousCharB = input[i];
            }
            if (!conditionBMet) return false;

            return true;
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
