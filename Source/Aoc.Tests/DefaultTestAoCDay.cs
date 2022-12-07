using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Solutions;

namespace Aoc.Tests
{
    public abstract class DefaultTestAoCDay
    {
        private const string DefaultFilePath = "Inputs\\Y{0}D{1}.txt";
        private const string SampleFilePath = "SampleInputs\\Sample_Y{0}D{1}.txt";


        protected DefaultTestAoCDay(string content, string sampleInput = "")
        {
            FileContent = content;
            SampleInput = sampleInput;
        }

        protected DefaultTestAoCDay(AoCPuzzle puzzle)
        {
            Puzzle = puzzle;

            string pathFileContent = string.Format(DefaultFilePath, puzzle.Year, $"{puzzle.Day}".PadLeft(2, '0'));
            string sampleFileContent = string.Format(SampleFilePath, puzzle.Year, $"{puzzle.Day}".PadLeft(2, '0'));

            FileContent = File.ReadAllText(pathFileContent);

            if (File.Exists(sampleFileContent))
                SampleInput = File.ReadAllText(sampleFileContent);

        }

        public string FileContent { get; protected set; }
        public AoCPuzzle Puzzle { get; protected set; }

        [SetUp]
        public abstract void Setup();

        [Test]
        public abstract void SampleTestA();

        [Test]
        public abstract void SampleTestB();


        [Test]
        public void RealTest() => AoCPuzzle.SolveVerbose(Puzzle, FileContent);

        protected string SampleInput { get; set; }


        protected void RunSampleTestA<T>(string input, T answer)
        {
            T ans = (T)Puzzle.SolvePuzzleA(input);
            Assert.That(ans, Is.EqualTo(answer));
        }

        protected void RunSampleTestB<T>(string input, T answer)
        {
            T ans = (T)Puzzle.SolvePuzzleB(input);
            Assert.That(ans, Is.EqualTo(answer));
        }




    }
}
