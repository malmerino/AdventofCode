﻿using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests.Y2015
{
    public class Day04 : DefaultAoCDay
    {

        public Day04() : base(File.ReadAllText("Inputs\\Y2015D04.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D02();
        }

        [Test]
        public override void SampleTestA()
        { }

        [Test]
        public override void SampleTestB()
        { }

    }
}
