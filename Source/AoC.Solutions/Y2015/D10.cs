using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Solutions.Y2015
{
    public class D10 : AoCPuzzle
    {
        public D10(string[] input) : base(input, 2015, 10)
        {
        }

        public override int SolvePuzzleA()
        {
            List<char> answer = GetInputAsString.ToCharArray().ToList();
            for (int _ = 0; _ < 40; _++)
            {
                answer = LookAndSaySequence(answer);
            }
            return answer.Count;
        }

        public override int SolvePuzzleB()
        {
            List<char> answer = GetInputAsString.ToCharArray().ToList();
            for (int _ = 0; _ < 50; _++)
            {
                answer = LookAndSaySequence(answer);
            }
            return answer.Count;
        }


        private List<char> LookAndSaySequence(IReadOnlyList<char> input)
        {

            List<char> result = new();
            int tempIncrement = 1;
            for (int i = 0; i < input.Count; i++)
            {
                if (i + 1 < input.Count && input[i] == input[i + 1])
                {
                    // Proceed and increment
                    tempIncrement++;
                }
                else
                {
                    // End this and start next
                    result.AddRange($"{tempIncrement}{input[i]}");

                    tempIncrement = 1;
                }
            }

            return result;
        }
    }
}