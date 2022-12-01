using AoC.Solutions.Y2015;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AoC.Solutions;
using static AoC.Solutions.Y2015.D14;

namespace Aoc.Tests.Y2015
{
    public class Day14 : DefaultTestAoCDay
    {

        public Day14() : base(File.ReadAllText("Inputs\\Y2015D14.txt")) { }

        public override void Setup()
        {
            Puzzle = new AoC.Solutions.Y2015.D14();
        }

        [Test]
        public override void SampleTestA()
        {
            if (Puzzle is D14 puzzle)
            {
                string input = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.\r\n" +
                               "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";


                List<D14.Reindeer> reindeer = (Puzzle as D14).GenerateReindeerList(input).ToList();

                List<D14.ReindeerSimulation> reindeerSimulation = reindeer.Select(reindeer1 =>
                    new D14.ReindeerSimulation()
                    {
                        Reindeer = reindeer1
                    }).ToList();


                reindeerSimulation.ForEach(puzzle.SetupReindeer);

                for (int i = 0; i < 1000; i++)
                {
                    reindeerSimulation.ForEach(puzzle.UpdateReindeer);
                }

                int comet = reindeerSimulation.First(x => x.Reindeer.Name == "Comet").DistanceFromStart;
                int dancer = reindeerSimulation.First(x => x.Reindeer.Name == "Dancer").DistanceFromStart;

                Assert.IsTrue(comet == 1120, $"Comet was expected to get 1120 but got {comet}");
                Assert.IsTrue(dancer == 1056, $"Dancer was expected to get 1056 but got {dancer}");
            }

        }

        [Test]
        public override void SampleTestB()
        {
            if (Puzzle is D14 puzzle)
            {
                string input = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.\r\n" +
                               "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";


                List<D14.Reindeer> reindeer = (Puzzle as D14).GenerateReindeerList(input).ToList();

                List<D14.ReindeerSimulation> reindeerSimulation = reindeer.Select(reindeer1 =>
                    new D14.ReindeerSimulation()
                    {
                        Reindeer = reindeer1
                    }).ToList();


                reindeerSimulation.ForEach(puzzle.SetupReindeer);

                for (int i = 0; i < 1000; i++)
                {
                    reindeerSimulation.ForEach(puzzle.UpdateReindeer);
                    reindeerSimulation.OrderByDescending(x => x.DistanceFromStart).First().Score++;

                }

                int comet = reindeerSimulation.First(x => x.Reindeer.Name == "Comet").Score;
                int dancer = reindeerSimulation.First(x => x.Reindeer.Name == "Dancer").Score;

                Assert.IsTrue(comet == 312, $"Comet was expected to get 312 but got {comet}");
                Assert.IsTrue(dancer == 688, $"Dancer was expected to get 688 but got {dancer}");
            }
        }
    }
}
