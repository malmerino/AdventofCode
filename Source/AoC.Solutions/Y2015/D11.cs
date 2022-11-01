using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Solutions.Y2015
{
    public class D11 : AoCPuzzle<string>
    {
        public D11(string[] input) : base(input, 2015, 11)
        { }


        public override string SolvePuzzleA()
        {
           return PasswordGenerator(GetInputAsString);
        }

        public override string SolvePuzzleB()
        {
            return PasswordGenerator(SolvePuzzleA());
        }



        private string PasswordGenerator(string currentPassword)
        {
            //cqjxxxyz
            char[] password = currentPassword.ToCharArray();
            while (true)
            {

                password[^1]++;

                for (int i = 7; i >= 0; i--)
                {
                    if (password[i] == 'z' + 1)
                    {
                        password[i - 1]++;
                        password[i] = 'a';
                    }
                }

                bool repeatPass = false;
                for (int i = 0; i < password.Length - 2; i++)
                {
                    if (password[i] + 1 == password[i + 1] &&
                        password[i + 1] + 1 == password[i + 2])
                    {
                        repeatPass = true;
                        break;
                    }
                }

                bool prohibitedChars = true;
                List<char> prohibitedLetters = new List<char> { 'i', 'o', 'l' };
                if (password.Any(x => prohibitedLetters.Contains(x)))
                {
                    prohibitedChars = false;
                }

                bool doubleChars = false;
                int occurrences = 0;
                for (int i = 0; i < password.Length - 1; i++)
                {
                    if (password[i] == password[i + 1])
                    {
                        i++;
                        occurrences++;
                    }
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