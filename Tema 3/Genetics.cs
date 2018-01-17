using System;
using System.Collections.Generic;

namespace Tema_3
{
    public static class Genetics
    {
        private static readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());

        public static int GetRandom(int min, int max)
        {
            return RandomGenerator.Next(min, max);
        }

        public static int Fitness(this List<int> input)
        {
            var fitness = 0;
            for (var i = 0; i < input.Count - 1; i++)
            for (var j = i + 1; j < input.Count; j++)
                if (Population.Adjacency[i, j] == 1 && input[i] == input[j])
                    fitness++;
            return fitness;
        }

        public static List<int> CrossOver(List<List<int>> parents)
        {
            var toReturn = new List<int>();
            var r = GetRandom(0, Population.Vertices);
            for (var i = 0; i <= r; i++)
                toReturn.Add(parents[0][i]);
            for (var i = r + 1; i < Population.Vertices; i++)
                toReturn.Add(parents[1][i]);
            return toReturn;
        }
    }
}