﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests.Y2022
{
    public class Day04 : DefaultTestAoCDay
    {
        private string sampleInput;
        public Day04() : base(File.ReadAllText("Inputs\\Y2022D04.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2022.D04();
            sampleInput = "2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8";
        }

        [Test]
        public override void SampleTestA()
        {
            RunSampleTestA(Puzzle, sampleInput, 2);
        }

        [Test]
        public override void SampleTestB()
        {
            RunSampleTestB(Puzzle, sampleInput, 4);

        }
    }
}
