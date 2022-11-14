using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using SpaceStation.Utilities.LINQ;

namespace AoC.Solutions.Y2015
{
    public class D13 : AoCPuzzle
    {
        public D13() : base(2015, 13)
        { }


        // 537 is too low

        public override object SolvePuzzleA(string input)
        {
            List<PersonHappiness> persons = GeneratePersonList(input).ToList();
            List<IEnumerable<string>> permutations = GetPermutations(persons);
            return GenerateSeatMap(permutations, persons).Max(x => x.Happiness);

        }
        public override object SolvePuzzleB(string input)
        {
            List<PersonHappiness> persons = GeneratePersonList(input).ToList();

            List<PersonHappiness> addMyself = new();
            foreach (PersonHappiness uniquePerson in persons.Where(uniquePerson => addMyself.All(x => x.Name != uniquePerson.Name)))
            {
                addMyself.Add(new PersonHappiness()
                {
                    Name = uniquePerson.Name,
                    WhenNextTo = "Me",
                    Happiness = 0
                });

                addMyself.Add(new PersonHappiness()
                {
                    Name = "Me",
                    WhenNextTo = uniquePerson.Name,
                    Happiness = 0
                });
            }

            persons = persons.Concat(addMyself).ToList();

            List<IEnumerable<string>> permutations = GetPermutations(persons);
            return GenerateSeatMap(permutations, persons).Max(x => x.Happiness);
        }

        private static List<IEnumerable<string>> GetPermutations(List<PersonHappiness> persons)
        {
            List<string> uniquePersons = persons
                .Select(x => x.Name)
                .GroupBy(x => x)
                .Select(x => x.First())
                .ToList();

            List<IEnumerable<string>> permutations = uniquePersons.GetPermutations().ToList();
            return permutations;
        }


        public IEnumerable<PersonHappiness> GeneratePersonList(string input)
        {
            /*  Group 1 => Name1
             *  Group 2 => Operation (lose/gain)
             *  Group 3 => Numeric Value
             *  Group 4 => Name2
             */
            string pattern = @"([a-zA-Z]*) would ([a-z]{4}) (\d*) .*to ([a-zA-Z]*)";
            foreach (string row in input.Split("\r\n"))
            {
                Match match = Regex.Match(row, pattern);



                int val = int.Parse(match.Groups[3].Value);
                yield return new PersonHappiness()
                {
                    Happiness = match.Groups[2].Value == "gain" ? val : -val,
                    Name = match.Groups[1].Value,
                    WhenNextTo = match.Groups[4].Value
                };
            }
        }


        List<TableSeating> GenerateSeatMap(List<IEnumerable<string>> permutations, List<PersonHappiness> persons)
        {
            List<TableSeating> temp = new List<TableSeating>();
            foreach (IEnumerable<string> orientation in permutations)
            {
                int happiness = 0;
                List<string> personTable = orientation.ToList();

                for (int i = 0; i < personTable.Count() - 1; i++)
                {
                    happiness += persons.First(x => x.Name == personTable[i] && x.WhenNextTo == personTable[i + 1]).Happiness;
                    happiness += persons.First(x => x.Name == personTable[i + 1] && x.WhenNextTo == personTable[i]).Happiness;
                }

                // Add the last person
                happiness += persons.First(x => x.Name == personTable.First() && x.WhenNextTo == personTable.Last()).Happiness;
                happiness += persons.First(x => x.Name == personTable.Last() && x.WhenNextTo == personTable.First()).Happiness;



                temp.Add(new TableSeating(personTable.ToArray(), happiness));
            }

            return temp;
        }



        public class PersonHappiness
        {
            public string Name { get; set; }
            public int Happiness { get; set; }
            public string WhenNextTo { get; set; }
        }

        private struct TableSeating
        {
            public string[] Persons { get; }
            public int Happiness { get; }

            public TableSeating(string[] persons, int happiness)
            {
                Persons = persons;
                Happiness = happiness;
            }
        }
    }
}