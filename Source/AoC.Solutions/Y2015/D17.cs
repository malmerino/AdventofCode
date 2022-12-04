namespace AoC.Solutions.Y2015
{
    public class D17 : AoCPuzzle
    {
        public D17() : base(2015, 17)
        {
        }

        public override object SolvePuzzleA(string input)
        {
            var containers = GetContainers(input);



            return 0;
        }

        public override object SolvePuzzleB(string input)
        {
            return 0;
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