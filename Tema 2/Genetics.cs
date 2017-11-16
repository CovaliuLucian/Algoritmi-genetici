using System;

namespace Tema_2
{
    public static class Genetics
    {
        public static int GetRandom(int min, int max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(min, max);
        }

        public static char Not(this char c)
        {
            return c == '0' ? '1' : '0';
        }

        public static string ToBinary(this int number)
        {
            return Convert.ToString(number, 2).PadLeft(32, number >= 0 ? '0' : '1');
        }

        public static int ToInt(this string number)
        {
            return Convert.ToInt32(number, 2);
        }
    }
}