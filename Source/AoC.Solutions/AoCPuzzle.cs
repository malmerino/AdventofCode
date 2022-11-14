using System.Diagnostics;

namespace AoC.Solutions
{
    public abstract class AoCPuzzle
    {
        public int Year { get; }
        public int Day { get; }
        

        protected AoCPuzzle(int year, int day)
        {
            Year = year;
            Day = day;
        }


        public abstract object SolvePuzzleA(string input);
        public abstract object SolvePuzzleB(string input);


        public static void SolveVerbose(AoCPuzzle puzzle, string input)
        {
            Stopwatch sw = Stopwatch.StartNew();

            object a = puzzle.SolvePuzzleA(input);
            Console.WriteLine($"Solve Year {puzzle.Year} Day {puzzle.Day} [A]: {a} | Took: {sw.Elapsed}");

            sw.Restart();

            object b = puzzle.SolvePuzzleB(input);
            Console.WriteLine($"Solve Year {puzzle.Year} Day {puzzle.Day} [B]: {b} | Took: {sw.Elapsed}");

            sw.Stop();

            Console.WriteLine($"Type: ({a.GetType()})");

        }
    }
}
