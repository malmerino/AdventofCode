using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2022
{
	public class D05 : AoCPuzzle
	{
		public D05() : base(2022, 05) { }

		public override object SolvePuzzleA(string input)
		{
			InterpretInstructions(input, out IEnumerable<MoveInstruction> moveInstructions, out Dictionary<int, string> stackInstructions);
			Dictionary<int, string> stacks = RunCraneInstructions9000(moveInstructions, stackInstructions);

			return stacks.Aggregate("", (sum, add) => sum + add.Value.Last());
		}

		public override object SolvePuzzleB(string input)
		{
			InterpretInstructions(input, out IEnumerable<MoveInstruction> moveInstructions, out Dictionary<int, string> stackInstructions);
			Dictionary<int, string> stacks = RunCraneInstructions9001(moveInstructions, stackInstructions);

			return stacks.Aggregate("", (sum, add) => sum + add.Value.Last());
		}


		private static Dictionary<int, string> RunCraneInstructions9000(IEnumerable<MoveInstruction> moveInstructions, Dictionary<int, string> stacks)
		{
			foreach (MoveInstruction instruction in moveInstructions)
			{
				for (int i = 0; i < instruction.Amount; i++)
				{
					stacks[instruction.Destination] += stacks[instruction.Source][^1..];
					stacks[instruction.Source] = stacks[instruction.Source][..^1];
				}
			}
			return stacks;
		}

		private static Dictionary<int, string> RunCraneInstructions9001(IEnumerable<MoveInstruction> moveInstructions, Dictionary<int, string> stacks)
		{
			foreach (MoveInstruction instruction in moveInstructions)
			{

				stacks[instruction.Destination] += stacks[instruction.Source][^instruction.Amount..];
				stacks[instruction.Source] = stacks[instruction.Source][..^instruction.Amount];

			}
			return stacks;
		}


		private static void InterpretInstructions(string input, out IEnumerable<MoveInstruction> moveInstructions, out Dictionary<int, string> stackInstructions)
		{
			string[] part = input.Split("\r\n\r\n");

			moveInstructions = LoadMoveInstructions(part[1]);

			IEnumerable<Stacks> stack = LoadInitialStack(part[0]);
			stackInstructions = stack.ToDictionary(s => s.Key, s => s.Values);
		}


		private static IEnumerable<MoveInstruction> LoadMoveInstructions(string input)
		{
			const string pattern = @"move (\d{1,3}) from (\d{1,3}) to (\d{1,3})";

			foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
			{
				int amount = int.Parse(match.Groups[1].Value);
				int source = int.Parse(match.Groups[2].Value);
				int destination = int.Parse(match.Groups[3].Value);

				yield return new MoveInstruction(amount, source, destination);
			}
		}

		private static IEnumerable<Stacks> LoadInitialStack(string input)
		{
			string[] rows = input.Split("\r\n");
			char[,] grid = new char[rows[0].Length, rows.Length];


			for (int x = 0; x < rows[0].Length; x++)
			{
				for (int y = 0; y < rows.Length; y++)
				{
					grid[x, y] = rows[y][x];
				}
			}

			int maxY = grid.GetLength(1) - 1;
			for (int x = 0; x < grid.GetLength(0) - 1; x++)
			{
				if (grid[x, maxY] == ' ') continue;

				string values = string.Empty;

				for (int y = maxY - 1; y >= 0; y--)
				{
					if (grid[x, y] == ' ') break;
					values += grid[x, y];
				}
				int key = int.Parse($"{grid[x, maxY]}");

				yield return new Stacks(key, values);
			}
		}

		private record MoveInstruction(int Amount, int Source, int Destination);
		private record Stacks(int Key, string Values);
	}
}

