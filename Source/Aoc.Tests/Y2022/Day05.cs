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

            sampleInput = "    [D]    \r\n" +
                          "[N] [C]    \r\n" +
                          "[Z] [M] [P]\r\n" +
                          " 1   2   3 " +
                          "\r\n\r\n" +
                          "move 1 from 2 to 1\r\n" +
                          "move 3 from 1 to 3\r\n" +
                          "move 2 from 2 to 1\r\n" +
                          "move 1 from 1 to 2";
        }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(Puzzle, sampleInput, "CMZ");
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(Puzzle, sampleInput, "MCD");
        }
    }
}
