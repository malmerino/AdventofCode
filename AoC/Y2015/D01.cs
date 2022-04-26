using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y2015
{
    public class D01 : AoCPuzzle
    {
        public D01(string[] input) : base(input)
        {
        }

        public override int SolvePuzzleA()
        {
            int currentFloor = 0;

            for (int i = 0; i < GetInputAsString.Length; i++)
            {
                if (GetInputAsString[i] == '(') currentFloor++;
                else if (GetInputAsString[i] == ')') currentFloor--;
            }

            return currentFloor;
        }

        public override int SolvePuzzleB()
        {
            int currentFloor = 0;
            int indexPadding = 1;
            int targetFloor = -1;

            for (int i = 0; i < GetInputAsString.Length; i++)
            {
                if (GetInputAsString[i] == '(') currentFloor++;
                else if (GetInputAsString[i] == ')') currentFloor--;

                if(currentFloor == targetFloor)
                {
                    return i + indexPadding;                    
                }
            }

            return int.MaxValue;
        }
    }
}
