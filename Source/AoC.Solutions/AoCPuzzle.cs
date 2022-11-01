using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
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
