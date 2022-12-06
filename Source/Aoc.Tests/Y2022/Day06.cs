using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable StringLiteralTypo

namespace Aoc.Tests.Y2022
{
    public class Day06 : DefaultTestAoCDay
    {

        public Day06() : base(File.ReadAllText("Inputs\\Y2022D06.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D06();
        }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(Puzzle, "bvwbjplbgvbhsrlpgdmjqwftvncz", 5);
            RunSampleTestA(Puzzle, "nppdvjthqldpwncqszvftbrmjlhg", 6);
            RunSampleTestA(Puzzle, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10);
            RunSampleTestA(Puzzle, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(Puzzle, "mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19);
            RunSampleTestB(Puzzle, "bvwbjplbgvbhsrlpgdmjqwftvncz", 23);
            RunSampleTestB(Puzzle, "nppdvjthqldpwncqszvftbrmjlhg", 23);
            RunSampleTestB(Puzzle, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29);
            RunSampleTestB(Puzzle, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26);
        }
    }
}
