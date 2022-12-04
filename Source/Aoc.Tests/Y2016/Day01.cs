using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2016
{
    public class Day01 : DefaultTestAoCDay
    {
        public Day01() : base(File.ReadAllText("Inputs/Y2016D01.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2016.D01();

        }

        public override void SampleTestA()
        {
            throw new NotImplementedException();
        }

        public override void SampleTestB()
        {
            throw new NotImplementedException();
        }
    }
}
