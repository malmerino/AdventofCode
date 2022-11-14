using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Solutions.Y2015
{
    public class D12 : AoCPuzzle
    {
        public D12() : base( 2015, 12)
        { }


        public override object SolvePuzzleA(string input)
        {
            string pattern = @"(-{0,1}\d{1,10})";
            Match matches = Regex.Match(input, pattern);

            
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

        public override object SolvePuzzleB(string input)
        {
            return 0;
        }



       
    }
}