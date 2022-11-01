namespace AoC.Solutions
{
    public abstract class AoCPuzzle<T>
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


        public abstract T SolvePuzzleA();

        public abstract T SolvePuzzleB();

        public void SolveAndWriteLine()
        {
            Console.WriteLine($"Type: ({typeof(T)})");

            T a = SolvePuzzleA();
            Console.WriteLine($"Solve Year {Year} Day {Day} [A]: {a}");

            T b = SolvePuzzleB();
            Console.WriteLine($"Solve Year {Year} Day {Day} [B]: {b}");

        }

    }
}
