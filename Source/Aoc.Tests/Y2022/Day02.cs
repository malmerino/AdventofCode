using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day02 : DefaultTestAoCDay
    {
        public Day02() : base(new AoC.Solutions.Y2022.D02()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 15);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 12);
        }
    }
}
