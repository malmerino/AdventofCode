using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day03 : DefaultTestAoCDay
    {
        public Day03() : base(new AoC.Solutions.Y2022.D03()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInputA, 157);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInputB, 70);
        }
    }
}
