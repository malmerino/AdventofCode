using System.Drawing;
using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2022
{
	public class D09 : AoCPuzzle
	{
		public D09() : base(2022, 09) { }



		public override object SolvePuzzleA(string input)
		{
			IEnumerable<Instruction> instructions = InterpreterInstruction(input);
			IEnumerable<Position> positions = SimulateRope(instructions);
			return positions.Count();
		}

		public override object SolvePuzzleB(string input)
		{
			IEnumerable<Instruction> instructions = InterpreterInstruction(input);
			IEnumerable<Position> positions = SimulateRopeWithAdvancedMoves(instructions);
			return positions.Count();
		}

		private static IEnumerable<Position> SimulateRope(IEnumerable<Instruction> instructions)
		{
			List<Position> positions = new();

			Position currentHead = new(1000, 1000);
			Position currentTail = currentHead with { };

			// Initial Tail
			positions.Add(currentHead with { });

			foreach (Instruction instruction in instructions)
			{
				for (int i = 0; i < instruction.Value; i++)
				{
					currentHead = MoveTowards(instruction, currentHead);

					if (Distance(currentTail, currentHead) <= 1) continue;

					currentTail = MoveTowardsPosition(currentTail, currentHead);

					if (!positions.Any(x => x.X == currentTail.X && x.Y == currentTail.Y))
						positions.Add(currentTail with { });
				}
			}
			return positions;
		}

		private static IEnumerable<Position> SimulateRopeWithAdvancedMoves(IEnumerable<Instruction> instructions)
		{
			List<Position> positions = new();

			Position head = new(1000, 1000);
			Position[] tails = new Position[9];

			// Initial Tail
			positions.Add(head with { });

			// Populate tails
			for (var i = 0; i < tails.Length; i++)
			{
				tails[i] = new Position(1000, 1000);
			}

			foreach (Instruction instruction in instructions)
			{
				for (int j = 0; j < instruction.Value; j++)
				{
					head = MoveTowards(instruction, head);

					if (Distance(tails[0], head) > 1)
					{
						tails[0] = MoveTowardsPosition(tails[0], head);

						if (!positions.Any(x => x.X == tails[0].X && x.Y == tails[0].Y))
							positions.Add(tails[0] with { });
					}

					for (int i = 1; i < tails.Length; i++)
					{
						if (Distance(tails[i], tails[i - 1]) > 1)
						{
							tails[i] = MoveTowardsPositionAdvanced(tails[i], tails[i - 1]);

							if (!positions.Any(x => x.X == tails[i].X && x.Y == tails[i].Y)) 
								positions.Add(tails[i] with { });
						}
					}
				}
			}

			return positions;
		}




		private static Position MoveTowardsPositionAdvanced(Position current, Position target)
		{
			if (current.X != target.X && current.Y == target.Y)
			{
				int deltaX = target.X - current.X;
				return current with { X = current.X + Math.Sign(deltaX) };
			}
			else if (current.Y != target.Y && current.X == target.X)
			{
				int deltaY = target.Y - current.Y;
				return current with { Y = current.Y + Math.Sign(deltaY) };
			}
			else
			{
				int deltaX = target.X - current.X;
				int deltaY = target.Y - current.Y;
				return new Position(X: current.X + Math.Sign(deltaX), Y: current.Y + Math.Sign(deltaY));
			}
		}



		private static Position MoveTowards(Instruction instruction, Position currentHead)
		{
			return instruction.Directions switch
			{
				Direction.Up => currentHead with { Y = currentHead.Y - 1 },
				Direction.Down => currentHead with { Y = currentHead.Y + 1 },
				Direction.Left => currentHead with { X = currentHead.X - 1 },
				Direction.Right => currentHead with { X = currentHead.X + 1 },
				_ => throw new ArgumentOutOfRangeException()
			};
		}


		private static int Distance(Position a, Position b) => (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

		private static Position MoveTowardsPosition(Position current, Position target)
		{
			int deltaX = target.X - current.X;
			int deltaY = target.Y - current.Y;

			int directionX = Math.Sign(deltaX);
			int directionY = Math.Sign(deltaY);

			// Create a new Position object representing the new position.
			return new Position(current.X + directionX, current.Y + directionY);
		}


		private static IEnumerable<Instruction> InterpreterInstruction(string input)
		{
			string pattern = @"(\S) (\d+)";

			MatchCollection ms = Regex.Matches(input, pattern, RegexOptions.Multiline);
			for (int index = 0; index < ms.Count; index++)
			{
				Match m = ms[index];
				Direction direction = (Direction)m.Groups[1].Value[0];
				int value = int.Parse(m.Groups[2].Value);

				yield return new Instruction(direction, value);
			}
		}

		private record Position(int X, int Y);

		private record Instruction(Direction Directions, int Value);

		private enum Direction
		{
			Up = 'U',
			Down = 'D',
			Left = 'L',
			Right = 'R'
		}
	}
}