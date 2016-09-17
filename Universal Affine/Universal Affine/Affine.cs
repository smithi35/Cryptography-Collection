using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Affine
{
    class Affine
    {
        public int Shift { get; set; }
        public int Multiplier { get; set; }
        public string Content { get; set; }

        private static List<int> PossibleMultipliers = new List<int> { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };

        public string Encode()
        {
            string output = "";
            Content = Content.ToUpper();
            foreach (char letter in Content)
            {
                int letterValue = letter - 'A';
                if (letterValue >= 0 && letterValue <= 25)
                {
                    letterValue = letterValue * Multiplier + Shift;
                    letterValue = letterValue % 26;
                    letterValue += 'A'; 
                    char outputLetter = (char)letterValue;
                    output = output + outputLetter;
                }
                else
                {
                    output = output + letter;
                }
            }
            return output;
        }

        private int getInverse()
        {
            int inverse = 0;
            foreach (int number in PossibleMultipliers)
            {
                if (number != Multiplier)
                {
                    int product = number * Multiplier;
                    int modified = product % 26;
                    if (modified == 1)
                    {
                        inverse = number;
                        break;
                    }
                }
            }
            return inverse;
        }

        public string Decode()
        {
            string output = "";
            int inverse = getInverse();
            Debug.WriteLine("Inverse = " + inverse);
            Content = Content.ToUpper();
            foreach(char letter in Content)
            {
                int letterValue = letter - 'A';

                if (letterValue >= 0 && letterValue <= 25)
                {

                    letterValue = (letterValue - Shift) * inverse;
                    letterValue %= 26;
                    letterValue += 'A';
                    char outputLetter = (char)letterValue;
                    output = output + outputLetter;
                }
                else
                {
                    output = output + letter;
                }
            }
            return output;
        }

        public static bool isPossibleMultiplier(int multiplier)
        {
            bool possible = false;
            foreach (int number in PossibleMultipliers)
            {
                if (multiplier == number)
                {
                    possible = true;
                    break;
                }
            }

            return possible;
        }
    }
}
