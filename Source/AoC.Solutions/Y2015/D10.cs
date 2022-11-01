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
            string answer = GetInputAsString;
            for (int _ = 0; _ < 40; _++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                LookAndSaySequence(ref answer);
                Console.WriteLine(_ + $" : {sw.Elapsed}");


            }
            return answer.Length;
        }

        public override int SolvePuzzleB()
        {
            string answer = GetInputAsString;
            for (int _ = 0; _ < 50; _++)
            {
                Stopwatch sw = Stopwatch.StartNew();

                LookAndSaySequence(ref answer);
                Console.WriteLine(_ + $" : {sw.Elapsed}");
            }
            return answer.Length;
        }


        private void LookAndSaySequence(ref string input)
        {
            char[] value = input.ToCharArray();

            List<char> result = new List<char>();
            int tempIncrement = 1;
            for (int i = 0; i < value.Length; i++)
            {
                if (i + 1 < value.Length && value[i] == value[i + 1])
                {
                    // Proceed and increment
                    tempIncrement++;
                }
                else
                {
                    // End this and start next
                    result.AddRange($"{tempIncrement}{value[i]}");

                    tempIncrement = 1;
                }

            }

            input = result.Aggregate("", (sum, add) => sum + add);
        }
    }
}
