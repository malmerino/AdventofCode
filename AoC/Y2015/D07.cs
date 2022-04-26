using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y2015
{
    internal class D07 : AoCPuzzle
    {


        public D07(string[] input) : base(input)
        {
        }

        public override int SolvePuzzleA()
        {
            return EvaluateRow("a", LoadInstructions());
        }

        public override int SolvePuzzleB()
        {
            ushort value = EvaluateRow("a", LoadInstructions());
            Dictionary<string, string[]> bitwiseInstructions = LoadInstructions();

            bitwiseInstructions["b"] = new string[] { "" + value, "->", "b" };

            return EvaluateRow("a", bitwiseInstructions);
        }

        private Dictionary<string, string[]> LoadInstructions()
        {
            Dictionary<string, string[]> bitwiseInstructions = new Dictionary<string, string[]>();

            foreach (string row in Input)
            {
                string[] data = row.Split(' ');
                bitwiseInstructions.Add(data.Last(), data);
            }
            return bitwiseInstructions;
        }

        private ushort EvaluateRow(string input, Dictionary<string, string[]> instructions)
        {
            ushort value;

            if (!ushort.TryParse(input, out value))
            {
                string[] values = instructions[input];

                if (values[1] == "->") value = EvaluateRow(values[0], instructions);
                else if (values[1] == "LSHIFT") value = (ushort)(EvaluateRow(values[0], instructions) << EvaluateRow(values[2], instructions));
                else if (values[1] == "RSHIFT") value = (ushort)(EvaluateRow(values[0], instructions) >> EvaluateRow(values[2], instructions));
                else if (values[0] == "NOT") value = (ushort)~EvaluateRow(values[1], instructions);
                else if (values[1] == "AND") value = (ushort)(EvaluateRow(values[0], instructions) & EvaluateRow(values[2], instructions));
                else if (values[1] == "OR") value = (ushort)(EvaluateRow(values[0], instructions) | EvaluateRow(values[2], instructions));
                else throw new Exception(string.Join("", values) + " is an unknown instruction");
                instructions[input] = new string[] { " " + value, "->", input };
            }


            return value;
        }










    }
}
