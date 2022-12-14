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
    public class Day15 : DefaultTestAoCDay
    {
  
        public Day15() : base(new AoC.Solutions.Y2015.D15()) { }

        public override void Setup() { }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(SampleInputA, 62842880);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(SampleInputB, 57600000);
        }
    }
}
