using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y2015
{
    internal class D06 : AoCPuzzle
    {
        public D06(string[] input) : base(input)
        { }

        public override int SolvePuzzleA()
        {
            int[,] grid = new int[1000, 1000];
            Fill2DIntegerArray(ref grid);

            foreach (string row in Input)
            {
                InterpretInstructions(row, ref grid, false);
            }


            return (from int item in grid where item == 1 select item).Count();
        }

        public override int SolvePuzzleB()
        {
            int[,] grid = new int[1000, 1000];
            Fill2DIntegerArray(ref grid);

            foreach (string row in Input)
            {
                InterpretInstructions(row, ref grid, true);
            }

            return (from int item in grid select item).Aggregate(0, (total, gridValue) => total + gridValue);
        }


        private void InterpretInstructions(string inputRow, ref int[,] grid, bool followRulesforPuzzleB)
        {
            string[] rowContents = inputRow.Split(' ');

            if (rowContents.Length == 4)
            {
                if (rowContents[0] == "toggle")
                {
                    GetStartEndPositions(rowContents[1], rowContents[3], out int[] startPos, out int[] endPos);

                    for (int x = startPos[0]; x <= endPos[0]; x++)
                    {
                        for (int y = startPos[1]; y <= endPos[1]; y++)
                        {
                            if (followRulesforPuzzleB) grid[x, y] += 2;
                            else grid[x, y] = Flip(grid[x, y]);
                        }
                    }
                }
                else throw new Exception(rowContents[0] + " is an unknown instruction");
            }
            else if (rowContents.Length == 5)
            {
                if (rowContents[0] == "turn")
                {
                    bool turnOn = rowContents[1] == "on";
                    GetStartEndPositions(rowContents[2], rowContents[4], out int[] startPos, out int[] endPos);

                    for (int x = startPos[0]; x <= endPos[0]; x++)
                    {
                        for (int y = startPos[1]; y <= endPos[1]; y++)
                        {
                            if (followRulesforPuzzleB)
                            {
                                if (turnOn) grid[x, y]++;
                                else grid[x, y]--;

                                if (grid[x, y] < 0) grid[x, y] = 0;

                            }
                            else
                            {
                                grid[x, y] = turnOn ? 1 : 0;
                            }
                        }
                    }
                }
                else throw new Exception(rowContents[0] + " is an unknown instruction");
            }
            else throw new Exception(rowContents[0] + " is an unknown instruction");
        }

        private void GetStartEndPositions(string startpos, string endpos, out int[] positionsStart, out int[] positionsEnd)
        {
            positionsStart = startpos.Split(',').Select(x => int.Parse(x)).ToArray();
            positionsEnd = endpos.Split(',').Select(x => int.Parse(x)).ToArray();
        }


        private int Flip(int content)
        {
            return content == 0 ? 1 : 0;
        }


        private void Fill2DIntegerArray(ref int[,] input)
        {
            for (int x = 0; x < input.GetLength(0); x++)
            {
                for (int y = 0; y < input.GetLength(1); y++)
                {
                    input[x, y] = 0;
                }
            }
        }
    }
}
