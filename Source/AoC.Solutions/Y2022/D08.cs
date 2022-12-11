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
                    if (GetEvaluationResult(input, x, y).CanBeSeenFromOutside) visible++;
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
                    int scenicScore = GetEvaluationResult(input, x, y).SceneryScore;

                    if (scenicScore > bestScore) bestScore = scenicScore;
                }
            }

            return bestScore;
        }

        private static EvaluationResult GetEvaluationResult(int[,] map, int x, int y)
        {
            int yLen = map.GetLength(0);
            int xLen = map.GetLength(1);
            int val = map[y, x];

            int[] score = new int[CommonDirections.Length];
            int index = 0;

            bool canBeSeen = false;

            foreach (Direction direction in CommonDirections)
            {
                int i = 1;
                while (true)
                {
                    int dX = x + direction.Dx * i;
                    int dY = y + direction.Dy * i;

                    if (x == 0 || y == 0 || x == xLen - 1 || y == yLen - 1)
                    {
                        score[index++] = 0;
                        canBeSeen = true;
                        break;
                    }


                    if (dX < 0 || dY < 0 || dX >= xLen || dY >= yLen)
                    {
                        score[index++] = i - 1;
                        canBeSeen = true;
                        break;
                    }

                    if (map[dY, dX] >= val)
                    {
                        score[index++] = i;
                        break;
                    }

                    i++;
                }
            }

            return new EvaluationResult(score.Aggregate(1, (sum, add) => sum * add), canBeSeen);
        }

        private record EvaluationResult(int SceneryScore, bool CanBeSeenFromOutside);

        private record Direction(int Dx, int Dy);

        private static readonly Direction[] CommonDirections = {
            new(1, 0),
            new(-1, 0),
            new(0, 1),
            new(0, -1),
        };
    }
}