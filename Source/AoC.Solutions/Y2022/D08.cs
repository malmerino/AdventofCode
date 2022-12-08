using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2022
{
    public class D08 : AoCPuzzle
    {
        public D08() : base(2022, 08) { }
        
        public override object SolvePuzzleA(string input)
        {
            int[,] map = GenerateMap(input);
            




            return 0;
        }

        public override object SolvePuzzleB(string input)
        {
            return 0;
        }



        private static int[,] GenerateMap(string input)
        {
            string[] rows = input.Split("\r\n");

            int[,] mapArray = new int[rows[0].Length, rows.Length];

            for (int y = 0; y < rows.Length; y++)
            {
                for (int x = 0; x < rows[0].Length; x++)
                {
                    mapArray[x, y] = int.Parse($"{rows[x][y]}");
                }
            }

            return mapArray;
        }
    }
}