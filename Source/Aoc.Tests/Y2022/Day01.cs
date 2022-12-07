using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day01 : DefaultTestAoCDay
    {
        public Day01() : base(new AoC.Solutions.Y2022.D01()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 24000);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 45000);
        }
    }
}
