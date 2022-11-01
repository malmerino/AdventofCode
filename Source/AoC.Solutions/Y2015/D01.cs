namespace AoC.Solutions.Y2015
{
    public class D01 : AoCPuzzle<int>
    {
        public D01(string[] input) : base(input,2015,1)
        {
        }

        public override int SolvePuzzleA()
        {
            return GetInputAsString.Aggregate(0, (sum, add) => sum + TranslateCharToFloor(add));
        }

        public override int SolvePuzzleB()
        {
            const int indexPadding = 1;
            const int targetFloor = -1;
            int currentFloor = 0;

            for (int i = 0; i < GetInputAsString.Length; i++)
            {
                currentFloor += TranslateCharToFloor(GetInputAsString[i]);

                if (currentFloor == targetFloor)
                {
                    return i + indexPadding;
                }
            }

            return int.MaxValue;
        }

        private static int TranslateCharToFloor(char input)
        {
            return input switch
            {
                '(' => 1,
                ')' => -1,
                _ => throw new ArgumentException($"{nameof(input)} value of {input} is not valid")
            };
        }
    }
}
