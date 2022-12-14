using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day08 : DefaultTestAoCDay
    {

        public Day08() : base(new AoC.Solutions.Y2015.D08()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInputA, 5);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInputB, 10);
        }

    }
}
