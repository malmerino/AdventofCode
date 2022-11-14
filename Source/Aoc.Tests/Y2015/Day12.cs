using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day12 : DefaultAoCDay
    {

        public Day12() : base(File.ReadAllText("Inputs\\Y2015D12.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D12();
        }

        [Test]
        public override void SampleTestA()
        {
            Assert.IsTrue(Puzzle.SolvePuzzleA(@"{""a"":2,""b"":4}") is 6);
            Assert.IsTrue(Puzzle.SolvePuzzleA(@"{""a"":{""b"":4},""c"":-1}") is 3);
            Assert.IsTrue(Puzzle.SolvePuzzleA(@"{}") is 0);
        }

        [Test]
        public override void SampleTestB()
        {
            Assert.IsTrue(Puzzle.SolvePuzzleB(@"{""d"":""red"",""e"":[1,2,3,4],""f"":5}") is 0);
            Assert.IsTrue(Puzzle.SolvePuzzleB(@"[1,""red"",5]") is 6);
        }

    }
}
