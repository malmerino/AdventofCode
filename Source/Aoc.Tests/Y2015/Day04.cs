using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day04 : DefaultTestAoCDay
    {

        public Day04() : base(new AoC.Solutions.Y2015.D04()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 609043);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 6742839);
        }

    }
}
