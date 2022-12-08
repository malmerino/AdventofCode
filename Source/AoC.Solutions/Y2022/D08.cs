using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2022
{
    public class D08 : AoCPuzzle
    {
        public D08() : base(2022, 08) { }

        public override object SolvePuzzleA(string input)
        {
            int[,] map = GenerateMap(input);
            return FindVisibleTrees(map);
        }

        public override object SolvePuzzleB(string input)
        {
            int[,] map = GenerateMap(input);
            return GetBestScenicScore(map);
        }
        

        private static int[,] GenerateMap(string input)
        {
            string[] rows = input.Split("\r\n");

            int[,] mapArray = new int[rows[0].Length, rows.Length];

            for (int y = 0; y < rows[0].Length; y++)
            {
                for (int x = 0; x < rows.Length; x++)
                {
                    mapArray[y, x] = int.Parse($"{rows[y][x]}");
                }
            }

            return mapArray;
        }


        private static int FindVisibleTrees(int[,] input)
        {
            int visible = 0;

            for (int y = 0; y < input.GetLength(0); y++)
            {
                for (int x = 0; x < input.GetLength(1); x++)
                {
                    if (OutsideTreesVisible(input, x, y)) visible++;
                }
            }

            return visible;
        }

        public static int GetBestScenicScore(int[,] input)
        {
            int bestScore = 0;

            for (int y = 0; y < input.GetLength(0); y++)
            {
                for (int x = 0; x < input.GetLength(1); x++)
                {
                    int scenicScore = GetScenicScore(input, x, y);

                    if (scenicScore > bestScore) bestScore = scenicScore;
                }
            }

            return bestScore;
        }


        private static int GetScenicScore(int[,] input, int x, int y)
        {
            int val = input[y, x];

            int yLen = input.GetLength(0);
            int xLen = input.GetLength(1);

            int down = 0;
            for (int i = y + 1; i < yLen; i++)
            {
                down++;
                if (input[i, x] >= val) break;
            }

            int up = 0;
            for (int i = y - 1; i >= 0; i--)
            {
                up++;
                if (input[i, x] >= val) break;
            }

            int right = 0;
            for (int i = x + 1; i < xLen; i++)
            {
                right++;
                if (input[y, i] >= val) break;
            }

            int left = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                left++;
                if (input[y, i] >= val) break;
            }


            return down * up * right * left;

        }

        private static bool OutsideTreesVisible(int[,] input, int x, int y)
        {
            int val = input[y, x];

            int yLen = input.GetLength(0);
            int xLen = input.GetLength(1);


            bool downOk = true;
            for (int i = y + 1; i < yLen; i++)
                if (input[i, x] >= val) downOk = false;

            bool upOk = true;
            for (int i = y - 1; i >= 0; i--)
                if (input[i, x] >= val) upOk = false;

            bool rightOk = true;
            for (int i = x + 1; i < xLen; i++)
                if (input[y, i] >= val) rightOk = false;

            bool leftOk = true;
            for (int i = x - 1; i >= 0; i--)
                if (input[y, i] >= val) leftOk = false;

            return upOk || downOk || rightOk || leftOk;
        }

    }
}