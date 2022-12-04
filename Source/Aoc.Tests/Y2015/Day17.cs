using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day17 : DefaultTestAoCDay
    {
        private readonly string sampleInput = "20\r\n15\r\n10\r\n5\r\n5";

        public Day17() : base(File.ReadAllText("Inputs\\Y2015D17.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D17();
        }

        [Test]
        public override void SampleTestA()
        {
            if (Puzzle is D17 puzzle)
            {
                int t = puzzle.Target;
                puzzle.Target = 25;
                int ans = (int)Puzzle.SolvePuzzleA(sampleInput);

                puzzle.Target = t;
                Assert.IsTrue(ans == 4, $"Expected 4 and got {ans}");
            }
            else Assert.Fail();
        }

        [Test]
        public override void SampleTestB()
        {
            // No samples available to create a test
        }
    }
}
