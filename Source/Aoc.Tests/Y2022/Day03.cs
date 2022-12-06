using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day03 : DefaultTestAoCDay
    {
        private string sampleInput;
        public Day03() : base(File.ReadAllText("Inputs\\Y2022D03.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D03();

            sampleInput = "vJrwpWtwJgWrhcsFMMfFFhFp\r\n" +
                          "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\n" +
                          "PmmdzqPrVvPwwTWBwg\r\n" +
                          "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\n" +
                          "ttgJtRGJQctTZtZT\r\n" +
                          "CrZsJsPPZsGzwwsLwLmpwMDw";
        }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(Puzzle, sampleInput, 157);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(Puzzle, sampleInput, 70);
        }
    }
}
