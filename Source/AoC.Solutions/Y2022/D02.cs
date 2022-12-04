namespace AoC.Solutions.Y2022
{
    public class D02 : AoCPuzzle
    {
        public D02() : base(2022, 02) { }

        public override object SolvePuzzleA(string input)
        {
            List<Round> gameResults = GetRoundInfoPuzzleA(input).ToList();

            return gameResults.Sum(round => (int)GetResultForRound(round) + (int)round.Player);
        }

        public override object SolvePuzzleB(string input)
        {
            List<Round> gameResults = GetRoundInfoPuzzleB(input).ToList();

            return gameResults.Sum(round => (int)GetResultForRound(round) + (int)round.Player);
        }


        private static IEnumerable<Round> GetRoundInfoPuzzleA(string input)
        {
            string[] rows = input.Split("\r\n");
            foreach (string row in rows)
            {
                string[] instructions = row.Split(' ');

                char player = instructions[1][0];
                char opponent = instructions[0][0];

                Play playersPlay = TranslateForPuzzleA(player);
                Play opponentsPlay = TranslateForPuzzleA(opponent);

                yield return new Round(playersPlay, opponentsPlay);
            }
        }

        private static IEnumerable<Round> GetRoundInfoPuzzleB(string input)
        {
            string[] rows = input.Split("\r\n");
            foreach (string row in rows)
            {
                string[] instructions = row.Split(' ');

                char player = instructions[1][0];
                char opponent = instructions[0][0];

                Play opponentsPlay = TranslateForPuzzleA(opponent);
                Play playersPlay = GetCounterPlayForPuzzleB(player, opponentsPlay);

                yield return new Round(playersPlay, opponentsPlay);
            }
        }

        private static Play TranslateForPuzzleA(char move) => move switch
        {
            'A' or 'X' => Play.Rock,
            'B' or 'Y' => Play.Paper,
            'C' or 'Z' => Play.Scissors,
            _ => throw new Exception($"Instruction for char \"{move}\" is unknown")
        };


        //X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"
        private static Play GetCounterPlayForPuzzleB(char result, Play opponent)
        {
            return result switch
            {
                // Lose
                'X' => opponent switch
                {
                    Play.Rock => Play.Scissors,
                    Play.Paper => Play.Rock,
                    Play.Scissors => Play.Paper,
                    _ => throw new Exception("Unknown Play")
                },
                // Draw
                'Y' => opponent,
                // Win
                'Z' => opponent switch
                {
                    Play.Rock => Play.Paper,
                    Play.Paper => Play.Scissors,
                    Play.Scissors => Play.Rock,
                    _ => throw new Exception("Unknown Play")
                },
                _ => throw new Exception("Unknown Instruction")
            };
        }


        private static Result GetResultForRound(Round round)
        {
            return round.Player switch
            {
                Play.Paper => round.Opponent switch
                {
                    Play.Paper => Result.Draw,
                    Play.Scissors => Result.Loss,
                    Play.Rock => Result.Win,
                    _ => throw new Exception("Unknown Play")
                },
                Play.Rock => round.Opponent switch
                {
                    Play.Paper => Result.Loss,
                    Play.Scissors => Result.Win,
                    Play.Rock => Result.Draw,
                    _ => throw new Exception("Unknown Play")
                },
                Play.Scissors => round.Opponent switch
                {
                    Play.Paper => Result.Win,
                    Play.Scissors => Result.Draw,
                    Play.Rock => Result.Loss,
                    _ => throw new Exception("Unknown Play")
                },
                _ => throw new Exception("Unknown Instruction")
            };
        }

        private record Round(Play Player, Play Opponent);

        private enum Play
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        private enum Result
        {
            Loss = 0,
            Draw = 3,
            Win = 6,
        }

    }
}
