using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable StringLiteralTypo

namespace AoC.Solutions.Y2022
{
    public class D04 : AoCPuzzle
    {
        public D04() : base(2022, 04) { }

        public override object SolvePuzzleA(string input)
        {
            IEnumerable<CleanupJob> cleanupJobs = GetCleanupJobs(input);
            return FindIntersections(cleanupJobs);
        }

        public override object SolvePuzzleB(string input)
        {
            IEnumerable<CleanupJob> cleanupJobs = GetCleanupJobs(input);
            return FindOverlaps(cleanupJobs);
        }
        
        private static IEnumerable<CleanupJob> GetCleanupJobs(string input)
        {
            string[] rows = input.Split("\r\n");

            foreach (string row in rows)
            {
                string[] data = row.Split('-', ',');
                int[] values = data.Select(int.Parse).ToArray();

                List<int> elf1 = new(), elf2 = new();

                for (int i = values[0]; i <= values[1]; i++) elf1.Add(i);
                for (int i = values[2]; i <= values[3]; i++) elf2.Add(i);
                
                yield return new CleanupJob(elf1.ToArray(), elf2.ToArray());
            }
        }

        private static int FindIntersections(IEnumerable<CleanupJob> input)
        {
            return input.Count(x => x.Elf1.Intersect(x.Elf2).Count() == x.Elf1.Length || x.Elf2.Intersect(x.Elf1).Count() == x.Elf2.Length);
        }
        

        private static int FindOverlaps(IEnumerable<CleanupJob> input)
        {
            return input.Count(x => x.Elf1.Intersect(x.Elf2).Any() || x.Elf2.Intersect(x.Elf1).Any());
        }


        private record CleanupJob(int[] Elf1, int[] Elf2);

    }
}
