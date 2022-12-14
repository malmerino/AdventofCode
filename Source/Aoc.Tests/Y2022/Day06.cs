using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable StringLiteralTypo

namespace Aoc.Tests.Y2022
{
    public class Day06 : DefaultTestAoCDay
    {

        public Day06() : base(new AoC.Solutions.Y2022.D06()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInputA, 10);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInputB, 29);
        }
    }
}
