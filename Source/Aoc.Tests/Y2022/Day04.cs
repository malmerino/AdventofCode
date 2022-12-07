using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day04 : DefaultTestAoCDay
    {

        public Day04() : base(new AoC.Solutions.Y2022.D04()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 2);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 4);

        }
    }
}
