using System;

namespace RatRace
{
    static public class RNG
    {
        private static Random _rng = new Random();

        public static int Range(int upper, int lower)
        {
            return _rng.Next(upper, lower);
        }
    }
}
