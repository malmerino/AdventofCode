namespace AoC.Solutions.Y2015
{
    public class D07 : AoCPuzzle
    {
        public D07() : base(2015, 7)
        {
        }

        public override object SolvePuzzleA(string input)
        {
            return EvaluateRow("a", LoadInstructions(input.Split("\r\n")));
        }

        public override object SolvePuzzleB(string input)
        {
            ushort value = EvaluateRow("a", LoadInstructions(input.Split("\r\n")));
            Dictionary<string, string[]> bitwiseInstructions = LoadInstructions(input.Split("\r\n"));

            bitwiseInstructions["b"] = new string[] { "" + value, "->", "b" };

            return EvaluateRow("a", bitwiseInstructions);
        }

        private static Dictionary<string, string[]> LoadInstructions(IEnumerable<string> input)
        {
            return input.Select(row => row.Split(' ')).ToDictionary(data => data.Last());
        }

        private static ushort EvaluateRow(string input, IDictionary<string, string[]> instructions)
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