using System;
using System.Collections.Generic;

namespace Tema_3
{
    public static class Generator
    {
        private static readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());

        private static double GetRandom(double min, double max)
        {
            return RandomGenerator.NextDouble() * (max - min) + min;
        }

        private static int GetRandom(int min, int max)
        {
            return RandomGenerator.Next(min, max + 1);
        }

        public static Population Generate(int size = 1)
        {
            var population = new Population {ValueList = new List<List<int>>(size)};
            for (var i = 0; i < size; i++)
            {
                population.ValueList.Add(new List<int>());
                for (var j = 0; j < Population.Vertices; j++)
                {
                    population.ValueList[i].Add(GetRandom(0,Population.ValidColors));
                }
            }
            return population;
        }
    }
}