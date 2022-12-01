using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day05 : DefaultTestAoCDay
    {

        public Day05() : base(File.ReadAllText("Inputs\\Y2015D05.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D05();
        }

        [Test]
        public override void SampleTestA()
        { }

        [Test]
        public override void SampleTestB()
        { }

    }
}
