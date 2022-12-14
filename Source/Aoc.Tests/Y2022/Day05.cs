using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day05 : DefaultTestAoCDay
    {
       public Day05() : base(new AoC.Solutions.Y2022.D05()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInputA, "CMZ");
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInputB, "MCD");
        }
    }
}
