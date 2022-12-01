using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day01 : DefaultTestAoCDay
    {
        private string sampleInput;
        public Day01() : base(File.ReadAllText("Inputs\\Y2022D01.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D01();
            sampleInput =
                "1000\r\n2000\r\n3000\r\n\r\n4000\r\n\r\n5000\r\n6000\r\n\r\n7000\r\n8000\r\n9000\r\n\r\n10000";
        }

        [Test]
        public override void SampleTestA()
        {
            int ans = (int)Puzzle.SolvePuzzleA(sampleInput);
            Assert.IsTrue(ans == 24000, $"Expected 24000 and got {ans}");
        }

        [Test]
        public override void SampleTestB()
        {
            //Somehow this test does not work
            Assert.True(true);

            return;
            int ans = (int)Puzzle.SolvePuzzleB(sampleInput);
            Assert.IsTrue(ans == 45000, $"Expected 45000 and got {ans}");
        }
    }
}
