using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day10 : DefaultTestAoCDay
    {

        public Day10() : base(new AoC.Solutions.Y2015.D10()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInputA, 237746);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInputB, 3369156);
        }
    }
}
