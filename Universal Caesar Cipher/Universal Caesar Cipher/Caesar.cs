using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Caesar_Cipher
{
    class Caesar
    {
        public string Input { get; set; }
        public int Offset { get; set; }

        public string Encode()
        {
            string input = Input.ToUpper();
            string output = "";

            foreach (char letter in input)
            {
                int value = letter - 65;
                value = value + Offset;

                if (value > 25)
                {
                    value = value % 25;
                }
                value = value + 65;
                output = output + ((char)value);
            }

            return output;
        }

        public string Decode()
        {
            string input = Input.ToUpper();
            string output = "";

            foreach (char letter in input)
            {
                int value = letter - 65;
                value = value - Offset;

                if (value < 0)
                {
                    value = value + 25;
                }

                value = value + 65;
                output = output + ((char)value);
            }

            return output;
        }
    }
}
