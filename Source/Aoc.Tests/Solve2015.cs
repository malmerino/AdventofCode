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
        public void SolveDay01(string input)
        {
            D01 s = new AoC.Solutions.Y2015.D01(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D02.txt")]
        public void SolveDay02(string input)
        {
            D02 s = new AoC.Solutions.Y2015.D02(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D03.txt")]
        public void SolveDay03(string input)
        {
            D03 s = new AoC.Solutions.Y2015.D03(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D04.txt")]
        public void SolveDay04(string input)
        {
            D04 s = new AoC.Solutions.Y2015.D04(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D05.txt")]
        public void SolveDay05(string input)
        {
            D05 s = new AoC.Solutions.Y2015.D05(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D06.txt")]
        public void SolveDay06(string input)
        {
            D06 s = new AoC.Solutions.Y2015.D06(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D07.txt")]
        public void SolveDay07(string input)
        {
            D07 s = new AoC.Solutions.Y2015.D07(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }
        [TestCase("Inputs\\Y2015D08.txt")]
        public void SolveDay08(string input)
        {
            D08 s = new AoC.Solutions.Y2015.D08(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D09.txt")]
        public void SolveDay09(string input)
        {
            D09 s = new AoC.Solutions.Y2015.D09(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D10.txt")]
        public void SolveDay10(string input)
        {
            D10 s = new AoC.Solutions.Y2015.D10(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }

        [TestCase("Inputs\\Y2015D11.txt")]
        public void SolveDay11(string input)
        {
            D11 s = new AoC.Solutions.Y2015.D11(File.ReadAllLines(input));
            s.SolveAndWriteLine();
            Assert.True(true);
        }






    }
}