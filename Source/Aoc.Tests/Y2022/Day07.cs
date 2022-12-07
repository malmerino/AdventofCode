using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable StringLiteralTypo

namespace Aoc.Tests.Y2022
{
    public class Day07 : DefaultTestAoCDay
    {

        public Day07() : base(File.ReadAllText("Inputs\\Y2022D07.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D07();
        }

        [Test]
        public override void SampleTestA()
        {
            //RunSampleTestA(Puzzle, "bvwbjplbgvbhsrlpgdmjqwftvncz", 5);
        }

        [Test]
        public override void SampleTestB()
        {
            //RunSampleTestB(Puzzle, "mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19);
        }
    }
}
