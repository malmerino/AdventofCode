using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using SpaceStation.Utilities.LINQ;
using static AoC.Solutions.Y2015.D14;

namespace AoC.Solutions.Y2015
{
    public class D14 : AoCPuzzle
    {
        public D14() : base(2015, 14)
        { }

        public override object SolvePuzzleA(string input)
        {
            List<Reindeer> reindeer = GenerateReindeerList(input).ToList();

            List<ReindeerSimulation> reindeerSimulation = reindeer.Select(reindeer1 => new ReindeerSimulation()
            {
                Reindeer = reindeer1
            }).ToList();

            reindeerSimulation.ForEach(SetupReindeer);


            for (int i = 0; i < 2503; i++)
            {
                reindeerSimulation.ForEach(UpdateReindeer);
            }
            

            return reindeerSimulation.Max(x => x.DistanceFromStart);

        }
        public override object SolvePuzzleB(string input)
        {
            List<Reindeer> reindeer = GenerateReindeerList(input).ToList();

            List<ReindeerSimulation> reindeerSimulation = reindeer.Select(reindeer1 => new ReindeerSimulation()
            {
                Reindeer = reindeer1
            }).ToList();

            reindeerSimulation.ForEach(SetupReindeer);


            for (int i = 0; i < 2503; i++)
            {
                reindeerSimulation.ForEach(UpdateReindeer);
                reindeerSimulation.OrderByDescending(x => x.DistanceFromStart).First().Score++;
            }
            
            return reindeerSimulation.Max(x => x.Score);

        }
        

        public IEnumerable<Reindeer> GenerateReindeerList(string input)
        {
            string pattern = @"([A-Z]{1}[a-z]*) can fly (\d*) km/s for (\d*).* for (\d*)";

            foreach (string row in input.Split("\r\n"))
            {
                /*  Group 1 => Name
                 *  Group 2 => Speed KM/S
                 *  Group 3 => Duration
                 *  Group 4 => Rest
                 */
                Match match = Regex.Match(row, pattern);

                int speed = int.Parse(match.Groups[2].Value);
                int duration = int.Parse(match.Groups[3].Value);
                int rest = int.Parse(match.Groups[4].Value);

                yield return new Reindeer()
                {
                    Name = match.Groups[1].Value,
                    Speed = speed,
                    Duration = duration,
                    Rest = rest
                };
            }


        }


        public void UpdateReindeer(ReindeerSimulation reindeer)
        {
            if (reindeer.RunTimer > 0)
            {
                reindeer.DistanceFromStart += reindeer.Reindeer.Speed;
                reindeer.RunTimer--;
            }
            else if (reindeer.RestTimer > 0)
            {
                reindeer.RestTimer--;
            }
            else
            {
                reindeer.RunTimer = reindeer.Reindeer.Duration;
                reindeer.RestTimer = reindeer.Reindeer.Rest;
                UpdateReindeer(reindeer);
            }

        }
        public void SetupReindeer(ReindeerSimulation reindeer)
        {
            reindeer.RunTimer = reindeer.Reindeer.Duration;
            reindeer.RestTimer = reindeer.Reindeer.Rest;
        }


        public class Reindeer
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public int Duration { get; set; }
            public int Rest { get; set; }
        }


        public class ReindeerSimulation
        {
            public Reindeer Reindeer { get; set; }

            public int DistanceFromStart { get; set; }

            public int RestTimer { get; set; }

            public int RunTimer { get; set; }

            public int Score { get; set; }

        }
    }
}