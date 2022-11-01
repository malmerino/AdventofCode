using AoC.Solutions.Y2015;
using NUnit;

namespace Aoc.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Inputs\\Y2015D01.txt")]
        public void SolveDay1(string input)
        {
            D01 s = new AoC.Solutions.Y2015.D01(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D02.txt")]
        public void SolveDay2(string input)
        {
            D02 s = new AoC.Solutions.Y2015.D02(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D03.txt")]
        public void SolveDay3(string input)
        {
            D03 s = new AoC.Solutions.Y2015.D03(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D04.txt")]
        public void SolveDay4(string input)
        {
            D04 s = new AoC.Solutions.Y2015.D04(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D05.txt")]
        public void SolveDay5(string input)
        {
            D05 s = new AoC.Solutions.Y2015.D05(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D06.txt")]
        public void SolveDay6(string input)
        {
            D06 s = new AoC.Solutions.Y2015.D06(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D07.txt")]
        public void SolveDay7(string input)
        {
            D07 s = new AoC.Solutions.Y2015.D07(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D08.txt")]
        public void SolveDay8(string input)
        {
            D08 s = new AoC.Solutions.Y2015.D08(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D09.txt")]
        public void SolveDay9(string input)
        {
            D09 s = new AoC.Solutions.Y2015.D09(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
    }
}