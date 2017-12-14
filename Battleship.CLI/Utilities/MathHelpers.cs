using System.Drawing;
using System;
namespace Battleship.CLI.Utilities
{
    public static class MathHelpers
    {
        public static T Clamp<T>(this T value, T max, T min) where T : IComparable<T>
        {
            T ret = value;

            if (value.CompareTo(max) > 0)
            {
                ret = max;
            }

            if (value.CompareTo(min) < 0)
            {
                ret = min;
            }

            return ret;
        }
    }
}