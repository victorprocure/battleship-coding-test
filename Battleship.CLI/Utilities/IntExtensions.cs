using System;
using System.Text;

namespace Battleship.CLI.Utilities
{
    public static class IntExtensions
    {
        public static string ToAlphabetLetter(this int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            var result = new StringBuilder(number / 26 + 1);

            while (--number >= 0)
            {
                result.Append(GetCharFromNumber(number));

                number /= 26;
            }

            return result.ToString();
        }

        private static char GetCharFromNumber(int number)
        {
            

            var base26 = number % 26;
            var asciiCode = 'A' + base26;

            return ((char)asciiCode);
        }
    }
}