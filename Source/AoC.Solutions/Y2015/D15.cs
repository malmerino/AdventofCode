using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        private record Ingredient(string Name, int Capacity, int Durability, int Flavor, int Texture, int Calories);
        private record IngredientRow(Ingredient Ingredient, int Teaspoons);
        private record Recipe(IEnumerable<IngredientRow> Rows);


        public override object SolvePuzzleA(string input)
        {
            IEnumerable<Ingredient> ingredients = ParseInput(input);
            IEnumerable<Recipe> recipes = CreateRecipes(ingredients);

            return recipes.Max(x => CalculateTotalNoCalories(x.Rows.ToList()));

        }
        public override object SolvePuzzleB(string input)
        {
            IEnumerable<Ingredient> ingredients = ParseInput(input);
            IEnumerable<Recipe> recipes = CreateRecipes(ingredients);
            IEnumerable<Recipe> recipeWith500Calories = recipes.Where(x => CalculateCalories(x.Rows) == 500);
            
            return recipeWith500Calories.Max(x => CalculateTotalNoCalories(x.Rows));

        }
        

        private static IEnumerable<Ingredient> ParseInput(string input)
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
                   select new Ingredient(match.Groups[1].Value, capacity, durability, flavor, texture, calories);
        }

        
        private static IEnumerable<Recipe> CreateRecipes(IEnumerable<Ingredient> inputIngredients)
        {
            Ingredient[] ingredients = inputIngredients as Ingredient[] ?? inputIngredients.ToArray();
            int[] iteratedArray = new int[ingredients.Length];
            iteratedArray[^1] = 100;
            
            while (true)
            {
                List<IngredientRow> rows = iteratedArray.Select((t, i) => new IngredientRow(ingredients[i], t)).ToList();
                Recipe recipe = new(rows);
                yield return recipe;

                IterateArray(ref iteratedArray);
                if (rows[0].Teaspoons == 100) break;
            }

        }

        private static void IterateArray(ref int[] iteratedArray)
        {

            if (iteratedArray[^1] > 0)
            {
                iteratedArray[^1]--;
                iteratedArray[^2]++;
            }
            else
            {
                for (int i = 1; i < iteratedArray.Length; i++)
                {
                    if (iteratedArray[i] != 100 - iteratedArray[..i].Sum()) continue;
                    iteratedArray[i - 1]++;
                    iteratedArray[i] = 0;
                    break;
                }
            }

            if (iteratedArray[^1] == 0)
            {
                iteratedArray[^1] = 100 - iteratedArray[..^1].Sum();
            }
        }



        private static int CalculateCapacity(IEnumerable<IngredientRow> input)
        {
            return input.Sum(x => x.Teaspoons * x.Ingredient.Capacity);
        }

        private static int CalculateDurability(IEnumerable<IngredientRow> input)
        {
            return input.Sum(x => x.Teaspoons * x.Ingredient.Durability);
        }

        private static int CalculateFlavor(IEnumerable<IngredientRow> input)
        {
            return input.Sum(x => x.Teaspoons * x.Ingredient.Flavor);
        }

        private static int CalculateTexture(IEnumerable<IngredientRow> input)
        {
            return input.Sum(x => x.Teaspoons * x.Ingredient.Texture);
        }
        private static int CalculateCalories(IEnumerable<IngredientRow> input)
        {
            return input.Sum(x => x.Teaspoons * x.Ingredient.Calories);
        }

        private static int CalculateTotalNoCalories(IEnumerable<IngredientRow> input)
        {
            IEnumerable<IngredientRow> ingredientRows = input as IngredientRow[] ?? input.ToArray();

            return Math.Max(CalculateCapacity(ingredientRows), 0) *
                   Math.Max(CalculateDurability(ingredientRows), 0) *
                   Math.Max(CalculateFlavor(ingredientRows), 0) *
                   Math.Max(CalculateTexture(ingredientRows), 0);
        }
    }
}