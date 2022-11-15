using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Solutions.Y2015
{
    public class D11 : AoCPuzzle
    {
        public D11() : base(2015, 11)
        { }


        public override object SolvePuzzleA(string input)
        {
            return PasswordGenerator(input);
        }

        public override object SolvePuzzleB(string input)
        {
            return PasswordGenerator(SolvePuzzleA(input) as string ?? string.Empty);
        }



        private static string PasswordGenerator(string currentPassword)
        {
            char[] password = currentPassword.ToCharArray();
            while (true)
            {

                password[^1]++;

                for (int i = 7; i >= 0; i--)
                {
                    if (password[i] != 'z' + 1) continue;
                    password[i - 1]++;
                    password[i] = 'a';
                }

                bool repeatPass = false;
                for (int i = 0; i < password.Length - 2; i++)
                {
                    if (password[i] + 1 != password[i + 1] || password[i + 1] + 1 != password[i + 2]) continue;
                    repeatPass = true;
                    break;
                }

                bool prohibitedChars = true;
                List<char> prohibitedLetters = new() { 'i', 'o', 'l' };
                if (password.Any(x => prohibitedLetters.Contains(x)))
                {
                    prohibitedChars = false;
                }

                bool doubleChars = false;
                int occurrences = 0;
                for (int i = 0; i < password.Length - 1; i++)
                {
                    if (password[i] != password[i + 1]) continue;
                    i++;
                    occurrences++;
                }

                if (occurrences >= 2) doubleChars = true;


                if (repeatPass && prohibitedChars && doubleChars)
                {
                    break;
                }

            }

            return new string(password);


        }
    }
}