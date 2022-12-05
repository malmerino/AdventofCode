using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day05 : DefaultTestAoCDay
    {
        private string sampleInput;
        public Day05() : base(File.ReadAllText("Inputs\\Y2022D05.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D05();
            sampleInput = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 \r\n\r\nmove 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";
        }

        [Test]
        public override void SampleTestA()
        {
            string ans = (string)Puzzle.SolvePuzzleA(sampleInput);
            Assert.IsTrue(ans == "CMZ", $"Expected CMZ and got {ans}");
        }

        [Test]
        public override void SampleTestB()
        {
            string ans = (string)Puzzle.SolvePuzzleB(sampleInput);
            Assert.IsTrue(ans == "MCD", $"Expected MCD and got {ans}");
        }
    }
}
