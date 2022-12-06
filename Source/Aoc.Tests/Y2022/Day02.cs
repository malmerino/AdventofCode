using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day02 : DefaultTestAoCDay
    {
        private string sampleInput;
        public Day02() : base(File.ReadAllText("Inputs\\Y2022D02.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D02();
            sampleInput = "A Y\r\nB X\r\nC Z";
        }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(Puzzle, sampleInput, 15);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(Puzzle, sampleInput, 12);
        }
    }
}
