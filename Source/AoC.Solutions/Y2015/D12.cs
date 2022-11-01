using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Solutions.Y2015
{
    public class D12 : AoCPuzzle<int>
    {
        public D12(string[] input) : base(input, 2015, 12)
        { }


        public override int SolvePuzzleA()
        {
            string pattern = @"(-{0,1}\d{1,10})";
            Match matches = Regex.Match(GetInputAsString, pattern);

            
            int val = 0;
            while (true)
            {
                Match v = matches.NextMatch();
                if (!v.Success) break;

                val += int.Parse(v.Value);

                matches = v;
            }




            return val;
        }

        public override int SolvePuzzleB()
        {
            return 0;
        }



       
    }
}