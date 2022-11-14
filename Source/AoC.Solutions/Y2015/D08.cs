using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2015
{
    public class D08 : AoCPuzzle
    {
        public D08() : base(2015, 8)
        {
        }

        public override object SolvePuzzleA(string input)
        {
            string[] split = input.Split('\n');

            int lengthReal = split.Aggregate(0, (total, value) => total + value.Length);
            int lengthUnEscaped = split.Aggregate(0, (total, value) => total + Regex.Unescape(value).Length - 2);
            return lengthReal - lengthUnEscaped;
        }

        public override object SolvePuzzleB(string input)
        {
            string[] split = input.Split('\n');

            string[] newInput = new string[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                newInput[i] += '"';
                for (int j = 0; j < split[i].Length; j++)
                {
                    if (split[i][j] == '"') newInput[i] += "\\\"";
                    else if (split[i][j] == '\\') newInput[i] += "\\\\";
                    else newInput[i] += split[i][j];
                }
                newInput[i] += '"';
            }

            int lengthNew = newInput.Aggregate(0, (total, value) => total + value.Length);
            int lengthReal = split.Aggregate(0, (total, value) => total + value.Length);

            return lengthNew - lengthReal;
        }
    }
}
