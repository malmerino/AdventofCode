namespace AoC.Solutions.Y2022
{
    public class D01 : AoCPuzzle
    {
        public D01() : base(2022, 01) { }

        public override object SolvePuzzleA(string input)
        {
            return GetElves(input).OrderByDescending(x => x.Calories).First().Calories;
        }

        public override object SolvePuzzleB(string input)
        {
            return GetElves(input).OrderByDescending(x => x.Calories).Take(3).Sum(x => x.Calories);
        }

        private static IEnumerable<Elf> GetElves(string input)
        {
            string[] rows = input.Split("\r\n");
            int calories = 0;

            foreach (string row in rows)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    int cal = calories;
                    calories = 0;
                    yield return new Elf(cal);
                }
                else calories += int.Parse(row);
            }

            yield return new Elf(calories);
        }

        private record Elf(int Calories);
    }
}
