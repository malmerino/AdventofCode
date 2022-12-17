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
            IEnumerable<Position> positions = SimulateRope(instructions, 2);
            return positions.Count();
        }

        public override object SolvePuzzleB(string input)
        {
            IEnumerable<Instruction> instructions = InterpreterInstruction(input);
            IEnumerable<Position> positions = SimulateRope(instructions, 10);
            return positions.Count();
        }

        private static IEnumerable<Position> SimulateRope(IEnumerable<Instruction> instructions, int length)
        {
            HashSet<Position> positions = new();
            List<Position> tails = Enumerable.Repeat(new Position(0, 0), length).ToList();

            foreach (Direction instruction in instructions.SelectMany(instruction => Enumerable.Repeat(instruction.Directions, instruction.Value)))
            {
                tails[0] = tails[0].MoveDirection(instruction);

                for (int i = 1; i < tails.Count; i++)
                {
                    tails[i] = tails[i].Follow(tails[i - 1]);
                }
                positions.Add(tails.Last());
            }

            return positions;
        }


        private static IEnumerable<Instruction> InterpreterInstruction(string input)
        {
            const string pattern = @"(\S) (\d+)";

            MatchCollection ms = Regex.Matches(input, pattern, RegexOptions.Multiline);
            for (int index = 0; index < ms.Count; index++)
            {
                Match m = ms[index];
                Direction direction = (Direction)m.Groups[1].Value[0];
                int value = int.Parse(m.Groups[2].Value);

                yield return new Instruction(direction, value);
            }
        }

        private record Position(int X, int Y)
        {
            public Position MoveDirection(Direction direction)
            {
                return direction switch
                {
                    Direction.Up => this with { Y = Y - 1 },
                    Direction.Down => this with { Y = Y + 1 },
                    Direction.Left => this with { X = X - 1 },
                    Direction.Right => this with { X = X + 1 },
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            public Position Follow(Position leader)
            {
                int deltaX = X - leader.X;
                int deltaY = Y - leader.Y;

                int absDeltaX = Math.Abs(deltaX);
                int absDeltaY = Math.Abs(deltaY);

                if (absDeltaX <= 1 && absDeltaY <= 1)
                {
                    return this;
                }
                if (deltaX == 0 && absDeltaY > 1)
                {
                    return this with { Y = Y - Math.Sign(deltaY) };
                }
                if (deltaY == 0 && absDeltaX > 1)
                {
                    return this with { X = X - Math.Sign(deltaX) };
                }

                return new Position(X - Math.Sign(deltaX), Y - Math.Sign(deltaY));
            }
        };

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