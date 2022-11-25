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

        public Day15() : base(File.ReadAllText("Inputs\\Y2015D15.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D15();
        }

        [Test]
        public override void SampleTestA()
        {
          

        }

        [Test]
        public override void SampleTestB()
        {
        
        }
    }
}
