using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using SpaceStation.Utilities.LINQ;

namespace AoC.Solutions.Y2015
{
    public class D15 : AoCPuzzle
    {
        public D15() : base(2015, 15)
        { }



        public override object SolvePuzzleA(string input)
        {
            return "";

        }
        public override object SolvePuzzleB(string input)
        {
            return "";

        }



        private IEnumerable<Ingredient> ParseInput(string input)
        {
            return from row in input.Split("\r\n")
                let pattern = @"([A-Z]{1}[a-z]*): capacity (-\d{1}|\d{1}), durability (-\d{1}|\d{1}), flavor (-\d{1}|\d{1}), texture (-\d{1}|\d{1}), calories (-\d{1}|\d{1})"
                select Regex.Match(row, pattern)
                into match
                let capacity = int.Parse(match.Groups[2].Value)
                let durability = int.Parse(match.Groups[3].Value)
                let flavor = int.Parse(match.Groups[4].Value)
                let texture = int.Parse(match.Groups[5].Value)
                let calories = int.Parse(match.Groups[6].Value)
                select new Ingredient()
            {
                Calories = calories,
                Texture = texture,
                Flavor = flavor,
                Durability = durability,
                Capacity = capacity,
                Name = match.Groups[1].Value,
            };
        }


        private class Ingredient
        {
            public string Name { get; set; }
            public int Capacity { get; set; }
            public int Durability { get; set; }
            public int Flavor { get; set; }
            public int Texture { get; set; }
            public int Calories { get; set; }
        }

    }
}