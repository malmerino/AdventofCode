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
        protected DefaultTestAoCDay(string content)
        {
            FileContent = content;
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


        protected static void RunSampleTestA<T>(AoCPuzzle puzzle, string input, T answer) where T : struct
        {
            T ans = (T)puzzle.SolvePuzzleA(input);
            Assert.That(ans, Is.EqualTo(answer));
        }

        protected static void RunSampleTestB<T>(AoCPuzzle puzzle, string input, T answer) where T : struct
        {
            T ans = (T)puzzle.SolvePuzzleB(input);
            Assert.That(ans, Is.EqualTo(answer));
        }


    }
}
