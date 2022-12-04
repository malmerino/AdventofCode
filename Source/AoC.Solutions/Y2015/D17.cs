using SpaceStation.Utilities.LINQ;

namespace AoC.Solutions.Y2015
{
    public class D17 : AoCPuzzle
    {
        public D17() : base(2015, 17)
        {
        }

        public int Target { get; set; } = 150;

        public override object SolvePuzzleA(string input)
        {
            IEnumerable<int> containers = GetContainers(input);
            IEnumerable<int[]> combinations = containers.GetCombinations();

            return combinations.Count(x=> x.Sum() == Target);
        }

        public override object SolvePuzzleB(string input)
        {
            IEnumerable<int> containers = GetContainers(input);
            IEnumerable<int[]> combinations = containers.GetCombinations();

            return combinations.Where(x => x.Sum() == Target).OrderBy(x=> x.Length).First().Length;
        }

        private IEnumerable<int> GetContainers(string input)
        {
            string[] rows = input.Split("\r\n");

            foreach (string row in rows)
            {
                yield return int.Parse(row);
            }
        }
    }
}