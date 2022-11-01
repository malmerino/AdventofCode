namespace AoC.Solutions
{
    public abstract class AoCPuzzle
    {
        public string[] Input { get; private set; }
        public int Year { get; }
        public int Day { get; }

        public string GetInputAsString => string.Join("", Input);


        protected AoCPuzzle(string[] input, int year, int day)
        {
            Input = input;
            Year = year;
            Day = day;
        }


        public abstract int SolvePuzzleA();

        public abstract int SolvePuzzleB();

        public void SolveAndWriteLine()
        {
            int a = SolvePuzzleA();
            Console.WriteLine($"Solve Year {Year} Day {Day} [A]: {a}");

            int b = SolvePuzzleB();
            Console.WriteLine($"Solve Year {Year} Day {Day} [B]: {b}");
        }

    }
}
