using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Tests
{
    public abstract class DefaultAoCDay
    {
        protected DefaultAoCDay(string content)
        {
            FileContent = content;
        }

        public string FileContent { get; protected set; }

        [SetUp]
        public abstract void Setup();


        [Test]
        public abstract void SampleTest();


        [Test]
        public abstract void RealTest();

    }
}
