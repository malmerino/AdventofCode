using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day17 : DefaultTestAoCDay
    {
        private readonly string sampleInput = "";

        public Day17() : base(File.ReadAllText("Inputs\\Y2015D17.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D17();
        }

        [Test]
        public override void SampleTestA()
        {
           // No samples available to create a test
        }

        [Test]
        public override void SampleTestB()
        {
            // No samples available to create a test
        }
    }
}
