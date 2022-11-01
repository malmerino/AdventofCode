using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y2015
{
    public class D02 : AoCPuzzle
    {
        public D02(string[] input) : base(input)
        { }

        public override int SolvePuzzleA()
        {
            List<Box> boxes = InterpretInput(Input);
            return boxes.Aggregate(0, (total, box) => total + (CalculateSurfaceArea(box) + CalculateExtraPaperForElves(box)));
        }

        public override int SolvePuzzleB()
        {
            List<Box> boxes = InterpretInput(Input);
            return boxes.Aggregate(0, (total, box) => total + (CalculateBoxVolume(box) + CalculateRibbonLength(box)));
        }


        private List<Box> InterpretInput(string[] input)
        {
            List<Box> boxes = new List<Box>();

            foreach (string row in Input)
            {
                boxes.Add(InterpretInputRow(row));
            }
            return boxes;
        }


        private Box InterpretInputRow(string row)
        {
            string[] rowContents = row.Split('x');
            int[] rowParsedContents = rowContents.Select(x => int.Parse(x)).ToArray();
            return new Box(rowParsedContents[0], rowParsedContents[1], rowParsedContents[2]);
        }


        private int CalculateSurfaceArea(Box box)
        {
            return
                (2 * box.Length * box.Width) +
                (2 * box.Width * box.Height) +
                (2 * box.Height * box.Length);
        }

        private int CalculateExtraPaperForElves(Box box)
        {
            int[] surfaces = { box.Length * box.Width, box.Width * box.Height, box.Height * box.Length };
            return surfaces.Min();
        }


        private int CalculateRibbonLength(Box box)
        {
            int[] surfaces = { 2 * box.Length + 2 * box.Width, 2 * box.Width + 2 * box.Height, 2 * box.Height + 2 * box.Length };

            return surfaces.Min();
        }

        private int CalculateBoxVolume(Box box)
        {
            return box.Length * box.Width * box.Height;
        }


        private struct Box
        {
            public int Length;
            public int Width;
            public int Height;

            public Box(int length, int width, int height)
            {
                Length = length;
                Width = width;
                Height = height;
            }
        }
    }
}
