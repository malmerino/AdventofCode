using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using SpaceStation.Utilities.LINQ;
// ReSharper disable PropertyCanBeMadeInitOnly.Local

namespace AoC.Solutions.Y2015
{
    public class D16 : AoCPuzzle
    {
        public D16() : base(2015, 16)
        { }


        private readonly Aunt lookForAunt = new(-1)
        {
            Cars = 2,
            Perfumes = 1,
            Cats = 7,
            Dogs = new List<DetailedAnimal>()
            {
                new("Samoyeds", 2),
                new("Pomeranians", 3),
                new("Akitas", 0),
                new("Vizslas", 0)
            },
            Goldfish = 5,
            Children = 3,
            Trees = 3
        };


        public override object SolvePuzzleA(string input)
        {
            IEnumerable<Aunt> aunts = LoadAunts(input);
            IEnumerable<Aunt> results = aunts.Where(x => x.ComparePuzzleA(lookForAunt));

            return results.First().HeadId;
        }

        public override object SolvePuzzleB(string input)
        {
            IEnumerable<Aunt> aunts = LoadAunts(input);
            IEnumerable<Aunt> results = aunts.Where(x => x.ComparePuzzleB(lookForAunt));

            return results.First().HeadId;
        }


        private static IEnumerable<Aunt> LoadAunts(string input)
        {
            string[] rows = input.Split("\r\n");

            string pattern = @"Sue (\d*): (.*)";

            foreach (string row in rows)
            {
                Match match = Regex.Match(row, pattern);
                int headId = int.Parse(match.Groups[1].Value);
                string[] things = match.Groups[2].Value.Split(',');

                Aunt aunt = new(headId);

                foreach (string thing in things)
                {
                    string stripSpaces = thing.Replace(" ", "");
                    string[] split = stripSpaces.Split(":");

                    string property = split[0].ToUpper()[0] + split[0][1..];
                    int amount = int.Parse(split[1]);

                    PropertyInfo? info = aunt.GetType().GetProperty(property) ?? null;

                    if (info == null)
                    {
                        if (knownDogs.Contains(property))
                        {
                            aunt.Dogs.Add(new DetailedAnimal(property, amount));
                        }
                        else
                        {
                            throw new Exception($"Property {property} is unknown");
                        }

                    }
                    else
                    {
                        info.SetValue(aunt, amount);
                    }
                }
                yield return aunt;
            }
        }



        private static string[] knownDogs = { "Samoyeds", "Pomeranians", "Akitas", "Vizslas" };


        private class Aunt
        {
            public Aunt(int headId)
            {
                HeadId = headId;
                Dogs = new List<DetailedAnimal>();
            }

            public int HeadId { get;}
            public int Children { get; set; } = -1;
            public int Cats { get; set; } = -1;
            public int Goldfish { get; set; } = -1;
            public int Trees { get; set; } = -1;
            public int Cars { get; set; } = -1;
            public int Perfumes { get; set; } = -1;
            public List<DetailedAnimal> Dogs { get; set; }
            
            public bool ComparePuzzleA(Aunt other)
            {
                if ((Children != -1 && Children != other.Children) ||
                    (Cats != -1 && Cats != other.Cats) ||
                    (Goldfish != -1 && Goldfish != other.Goldfish) ||
                    (Trees != -1 && Trees != other.Trees) ||
                    (Cars != -1 && Cars != other.Cars) ||
                    (Perfumes != -1 && Perfumes != other.Perfumes)) return false;

                return !Dogs.Any() || other.Dogs.Where(dog => Dogs.Any(x => x.Name == dog.Name))
                    .All(dog => Dogs.First(x => x.Name == dog.Name).Amount == dog.Amount);
            }


            public bool ComparePuzzleB(Aunt other)
            {
                if ((Children != -1 && Children != other.Children) ||
                    (Cats != -1 && Cats <= other.Cats) ||
                    (Trees != -1 && Trees <= other.Trees) ||
                    (Goldfish != -1 && Goldfish >= other.Goldfish) ||
                    (Cars != -1 && Cars != other.Cars) ||
                    (Perfumes != -1 && Perfumes != other.Perfumes)) return false;
                if (!Dogs.Any()) return true;

                foreach (DetailedAnimal dog in other.Dogs.Where(dog => Dogs.Any(x => x.Name == dog.Name)))
                {
                    if (dog.Name == "Pomeranians")
                    {
                        if (Dogs.First(x => x.Name == dog.Name).Amount >= dog.Amount) return false;
                    }
                    else if (Dogs.First(x => x.Name == dog.Name).Amount != dog.Amount) return false;
                }

                return true;
            }
        }

        private record DetailedAnimal(string Name, int Amount);

    }
}