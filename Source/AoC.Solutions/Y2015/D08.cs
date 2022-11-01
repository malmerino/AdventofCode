﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Y2015
{
    internal class D08 : AoCPuzzle
    {
        public D08(string[] input) : base(input)
        {
        }

        public override int SolvePuzzleA()
        {
            int lengthReal = Input.Aggregate(0, (total, value) => total + value.Length);
            int lengthUnEscaped = Input.Aggregate(0, (total, value) => total + Regex.Unescape(value).Length - 2);
            return lengthReal - lengthUnEscaped;
        }

        public override int SolvePuzzleB()
        {
            string[] newInput = new string[Input.Length];
            for (int i = 0; i < Input.Length; i++)
            {
                newInput[i] += '"';
                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (Input[i][j] == '"') newInput[i] += "\\\"";
                    else if (Input[i][j] == '\\') newInput[i] += "\\\\";
                    else newInput[i] += Input[i][j];
                }
                newInput[i] += '"';
            }

            int lengthNew = newInput.Aggregate(0, (total, value) => total + value.Length);
            int lengthReal = Input.Aggregate(0, (total, value) => total + value.Length);

            return lengthNew - lengthReal;
        }
    }
}
