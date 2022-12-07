using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AoC.Solutions;
using static AoC.Solutions.Y2015.D14;

namespace Aoc.Tests.Y2015
{
    public class Day14 : DefaultTestAoCDay
    {

        public Day14() : base(new AoC.Solutions.Y2015.D14()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInput, 2660);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInput, 1558);
        }
    }
}
