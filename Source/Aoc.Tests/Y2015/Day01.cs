using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day01 : DefaultAoCDay
    {
        public Day01() : base(File.ReadAllText("Inputs\\Y2015D01.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D01();
        }

        [Test]
        public override void SampleTestA()
        {
            Assert.IsTrue(Puzzle.SolvePuzzleA("(())") is 0);
            Assert.IsTrue(Puzzle.SolvePuzzleA("()()") is 0);
            
            Assert.IsTrue(Puzzle.SolvePuzzleA("(()(()(") is 3);
            Assert.IsTrue(Puzzle.SolvePuzzleA("))(((((") is 3);

            Assert.IsTrue(Puzzle.SolvePuzzleA("())") is -1);
            Assert.IsTrue(Puzzle.SolvePuzzleA("))(") is -1);

            Assert.IsTrue(Puzzle.SolvePuzzleA(")))") is -3);
            Assert.IsTrue(Puzzle.SolvePuzzleA(")())())") is -3);
        }

        [Test]
        public override void SampleTestB()
        {
            Assert.True(true, "No Tests");
        }

    }
}
