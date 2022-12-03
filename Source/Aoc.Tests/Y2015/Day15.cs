using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AoC.Solutions;
using static AoC.Solutions.Y2015.D14;

namespace Aoc.Tests.Y2015
{
    public class Day15 : DefaultTestAoCDay
    {
        private readonly string sampleInput =
            "Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8\r\nCinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3";

        public Day15() : base(File.ReadAllText("Inputs\\Y2015D15.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D15();
        }

        [Test]
        public override void SampleTestA()
        {
            int ans = (int)Puzzle.SolvePuzzleA(sampleInput);
            Assert.IsTrue(ans == 62842880, $"Expected 62842880 and got {ans}");
        }

        [Test]
        public override void SampleTestB()
        {
            int ans = (int)Puzzle.SolvePuzzleB(sampleInput);
            Assert.IsTrue(ans == 57600000, $"Expected 57600000 and got {ans}");
        }
    }
}
