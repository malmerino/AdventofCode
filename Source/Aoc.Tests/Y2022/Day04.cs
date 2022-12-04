using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day04 : DefaultTestAoCDay
    {
        private string sampleInput;
        public Day04() : base(File.ReadAllText("Inputs\\Y2022D04.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D04();
            sampleInput = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg\r\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw";
        }

        [Test]
        public override void SampleTestA()
        {
            int ans = (int)Puzzle.SolvePuzzleA(sampleInput);
            Assert.IsTrue(ans == 157, $"Expected 157 and got {ans}");
        }

        [Test]
        public override void SampleTestB()
        {
            int ans = (int)Puzzle.SolvePuzzleB(sampleInput);
            Assert.IsTrue(ans == 70, $"Expected 70 and got {ans}");
        }
    }
}
