namespace AoC.Solutions.Y2015
{
    public class D02 : AoCPuzzle
    {
        public D02(string[] input) : base(input,2015,2)
        { }

        public override int SolvePuzzleA()
        {
            IEnumerable<Box> boxes = InterpretInput(Input);
            return boxes.Aggregate(0, (total, box) => total + (CalculateSurfaceArea(box) + CalculateExtraPaperForElves(box)));
        }

        public override int SolvePuzzleB()
        {
            IEnumerable<Box> boxes = InterpretInput(Input);
            return boxes.Aggregate(0, (total, box) => total + (CalculateBoxVolume(box) + CalculateRibbonLength(box)));
        }


        private IEnumerable<Box> InterpretInput(string[] input)
        {
            return Input.Select(InterpretInputRow).ToList();
        }


        private static Box InterpretInputRow(string row)
        {
            string[] rowContents = row.Split('x');
            int[] rowParsedContents = rowContents.Select(x => int.Parse(x)).ToArray();
            return new Box(rowParsedContents[0], rowParsedContents[1], rowParsedContents[2]);
        }


        private static int CalculateSurfaceArea(Box box)
        {
            return
                (2 * box.Length * box.Width) +
                (2 * box.Width * box.Height) +
                (2 * box.Height * box.Length);
        }

        private static int CalculateExtraPaperForElves(Box box)
        {
            int[] surfaces = { box.Length * box.Width, box.Width * box.Height, box.Height * box.Length };
            return surfaces.Min();
        }


        private static int CalculateRibbonLength(Box box)
        {
            int[] surfaces = { 2 * box.Length + 2 * box.Width, 2 * box.Width + 2 * box.Height, 2 * box.Height + 2 * box.Length };

            return surfaces.Min();
        }

        private static int CalculateBoxVolume(Box box)
        {
            return box.Length * box.Width * box.Height;
        }


        private struct Box
        {
            public readonly int Length;
            public readonly int Width;
            public readonly int Height;

            public Box(int length, int width, int height)
            {
                Length = length;
                Width = width;
                Height = height;
            }
        }
    }
}
