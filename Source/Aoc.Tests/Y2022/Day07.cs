using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable StringLiteralTypo

namespace Aoc.Tests.Y2022
{
    public class Day07 : DefaultTestAoCDay
    {

        public Day07() : base(new AoC.Solutions.Y2022.D07()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 95437);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 24933642);
        }
    }
}
