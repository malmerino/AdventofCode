using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable StringLiteralTypo

namespace Aoc.Tests.Y2022
{
    public class Day08 : DefaultTestAoCDay
    {

        public Day08() : base(new AoC.Solutions.Y2022.D08()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 21);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 8);
        }
    }
}
