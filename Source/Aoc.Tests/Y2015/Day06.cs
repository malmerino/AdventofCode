using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day06 : DefaultTestAoCDay
    {

        public Day06() : base(new AoC.Solutions.Y2015.D06()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 999996);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 1999996);
        }
    }
}
