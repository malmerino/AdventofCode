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
        protected DefaultTestAoCDay(string content, string sampleInput = "")
        {
            FileContent = content;
            SampleInput = sampleInput;
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

        protected void RunSampleTestB<T>( string input, T answer) 
        {
            T ans = (T)Puzzle.SolvePuzzleB(input);
            Assert.That(ans, Is.EqualTo(answer));
        }


    }
}
