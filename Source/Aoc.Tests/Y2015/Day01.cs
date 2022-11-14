using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2015
{
    public class Day01 : DefaultAoCDay
    {
       
        public Day01() : base(File.ReadAllText("Inputs\\Y2015D01.txt")) { }

        public override void Setup()
        {
        }

        public override void SampleTest()
        {
            throw new NotImplementedException();
        }

        public override void RealTest()
        {
            D01 s = new AoC.Solutions.Y2015.D01(FileContent.Split('\n'));
            s.SolveAndWriteLine();
            Assert.True(true);
            // todo: change above to be more generic
        }

        
    }
}
