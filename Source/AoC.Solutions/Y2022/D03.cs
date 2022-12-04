
// ReSharper disable StringLiteralTypo

namespace AoC.Solutions.Y2022
{
    public class D03 : AoCPuzzle
    {
        public D03() : base(2022, 03) { }

        public override object SolvePuzzleA(string input)
        {
            IEnumerable<Rucksack> rucksacks = GenerateRucksacks(input);
            return GetPriorities(rucksacks);
        }

        public override object SolvePuzzleB(string input)
        {
            IEnumerable<Rucksack> rucksacks = GenerateRucksacks(input);
            IEnumerable<char> badges = GetBadges(rucksacks.ToArray());
            return badges.Sum(x => Alphabet.IndexOf(x) + 1);
        }

        private static IEnumerable<Rucksack> GenerateRucksacks(string input)
        {
            string[] rows = input.Split("\r\n");

            foreach (string rucksack in rows)
            {
                string compartment1 = rucksack[..(rucksack.Length / 2)];
                string compartment2 = rucksack[(rucksack.Length / 2)..];

                yield return new Rucksack(rucksack, compartment1, compartment2);
            }
        }

        private static int GetPriorities(IEnumerable<Rucksack> rucksacks)
        {
            return rucksacks.Select(rucksack => rucksack.Compartment1.First(x => rucksack.Compartment2.Contains(x)))
                .Select(commonItem => Alphabet.IndexOf(commonItem) + 1)
                .Sum();
        }

        private static IEnumerable<char> GetBadges(Rucksack[] rucksacks)
        {
            for (int i = 0; i < rucksacks.Length; i += 3)
            {
                Rucksack[] group = rucksacks[i..(i + 3)];
                foreach (char t1 in Alphabet.Where(t1 => group.All(x => x.Combined.Contains(t1))))
                {
                    yield return t1;
                }
            }
        }

        private record Rucksack(string Combined, string Compartment1, string Compartment2);


        private static string Alphabet => @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    }
}
