using System;
using System.Collections.Generic;
using Functions;

namespace Tema_2_Prim
{
    public static class Generator
    {
        private static readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());

        private static double GetRandom(double min, double max)
        {
            return RandomGenerator.NextDouble() * (max - min) + min;
        }

        private static List<string> GenerateList(int dimensions, double min, double max)
        {
            if (dimensions < 1)
                throw new InvalidArgsException();

            var toReturn = new List<string>();

            for (var i = 0; i < dimensions; i++)
                toReturn.Add(GetRandom(min, max).ToBinary());

            return toReturn;
        }

        public static Population GeneratePopulation(int dimensions, double min, double max, int count = 1)
        {
            if (count < 1)
                throw new InvalidArgsException();

            var toReturn = new List<List<string>>();
            for (var i = 0; i < count; i++)
                toReturn.Add(GenerateList(dimensions, min, max));
            return new Population(toReturn);
        }

        public static Population GeneratePopulation(int dimensions, IFunction function, int size = 1)
        {
            return GeneratePopulation(dimensions, (double) function.SearchMinimum, (double) function.SearchMaximum,
                size);
        }
    }
}