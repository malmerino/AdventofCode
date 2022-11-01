namespace AoC.Solutions.Y2015
{
    public class D07 : AoCPuzzle
    {
        public D07(string[] input) : base(input, 2015,7)
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

        private ushort EvaluateRow(string input, IDictionary<string, string[]> instructions)
        {
            // Returns value if row entry is resolved
            if (ushort.TryParse(input, out ushort value)) return value;
            string[] values = instructions[input];
            if (values[0] == "NOT") value = (ushort)~EvaluateRow(values[1], instructions);
            else
                switch (values[1])
                {
                    case "->":
                        value = EvaluateRow(values[0], instructions);
                        break;
                    case "LSHIFT":
                        value = (ushort)(EvaluateRow(values[0], instructions) << EvaluateRow(values[2], instructions));
                        break;
                    case "RSHIFT":
                        value = (ushort)(EvaluateRow(values[0], instructions) >> EvaluateRow(values[2], instructions));
                        break;
                    case "AND":
                        value = (ushort)(EvaluateRow(values[0], instructions) & EvaluateRow(values[2], instructions));
                        break;
                    case "OR":
                        value = (ushort)(EvaluateRow(values[0], instructions) | EvaluateRow(values[2], instructions));
                        break;
                    default:
                        throw new Exception(string.Join("", values) + " is an unknown instruction");
                }

            instructions[input] = new string[] { " " + value, "->", input };

            return value;
        }
    }
}