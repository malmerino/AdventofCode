using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day13 : DefaultTestAoCDay
    {

        public Day13() : base(File.ReadAllText("Inputs\\Y2015D13.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D13();
        }

        [Test]
        public override void SampleTestA()
        {
            string input =
                "Alice would gain 54 happiness units by sitting next to Bob.\r\n" +
                "Alice would lose 79 happiness units by sitting next to Carol.\r\n" +
                "Alice would lose 2 happiness units by sitting next to David.\r\n" +
                "Bob would gain 83 happiness units by sitting next to Alice.\r\n" +
                "Bob would lose 7 happiness units by sitting next to Carol.\r\n" +
                "Bob would lose 63 happiness units by sitting next to David.\r\n" +
                "Carol would lose 62 happiness units by sitting next to Alice.\r\n" +
                "Carol would gain 60 happiness units by sitting next to Bob.\r\n" +
                "Carol would gain 55 happiness units by sitting next to David.\r\n" +
                "David would gain 46 happiness units by sitting next to Alice.\r\n" +
                "David would lose 7 happiness units by sitting next to Bob.\r\n" +
                "David would gain 41 happiness units by sitting next to Carol.";

            int ans = (int)Puzzle.SolvePuzzleA(input);
            Assert.IsTrue(ans == 330, $"Answer for example was invalid, expected 330 got {ans}");

        }

        [Test]
        public override void SampleTestB()
        { }
    }
}
