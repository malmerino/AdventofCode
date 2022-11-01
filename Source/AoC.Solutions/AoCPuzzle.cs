namespace AoC.Solutions
{
    public abstract class AoCPuzzle
    {
        public string[] Input { get; private set; }

        public string GetInputAsString => string.Join("", Input);


        protected AoCPuzzle(string[] input)
        {
            Input = input;
        }


        public abstract int SolvePuzzleA();

        public abstract int SolvePuzzleB();



    }
}
