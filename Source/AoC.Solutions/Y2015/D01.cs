namespace AoC.Solutions.Y2015
{
    public class D01 : AoCPuzzle
    {
        public D01() : base(2015, 1) { }


        private static int TranslateCharToFloor(char input)
        {
            return input switch
            {
                '(' => 1,
                ')' => -1,
                _ => throw new ArgumentException($"{nameof(input)} value of {input} is not valid")
            };
        }

        public override object SolvePuzzleA(string input)
        {
            return input.Sum(TranslateCharToFloor);
        }

        public override object SolvePuzzleB(string input)
        {
            const int indexPadding = 1;
            const int targetFloor = -1;
            int currentFloor = 0;

            for (int i = 0; i < input.Length; i++)
            {
                currentFloor += TranslateCharToFloor(input[i]);

                if (currentFloor == targetFloor)
                {
                    return i + indexPadding;
                }
            }

            return int.MinValue;
        }
    }
}
