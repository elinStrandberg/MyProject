using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    static class RandomUtils
    {
        public static int RandomGenerator(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue);
        }

        public static bool CheckPercentage(int percentageValue)
        {
            Random random = new Random();

            if (random.Next(0, 100) < percentageValue)
                return true;
            else return false;
        }
    }
}