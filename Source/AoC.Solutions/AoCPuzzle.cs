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


        public abstract object SolvePuzzleA(string entry);
        public abstract object SolvePuzzleB(string entry);
    }
}
