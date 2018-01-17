using System;
using System.Collections.Generic;
using System.Linq;

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
            return input.Conflicts() + input.UsedColors();
        }

        public static int Conflicts(this List<int> input)
        {
            if (input == null)
                return 999999;
            var fitness = 0;
            for (var i = 0; i < input.Count - 1; i++)
            for (var j = i + 1; j < input.Count; j++)
                if (Population.Adjacency[i, j] == 1 && input[i] == input[j])
                    fitness++;
            return fitness;
        }

        public static List<int> CrossOver(this List<List<int>> parents)
        {
            var toReturn = new List<int>();
            var r = GetRandom(0, Population.Vertices);
            for (var i = 0; i <= r; i++)
                toReturn.Add(parents[0][i]);
            for (var i = r + 1; i < Population.Vertices; i++)
                toReturn.Add(parents[1][i]);
            return toReturn;
        }

        public static int MostUsed(List<List<int>> input, int pos)
        {
            var counts = new List<int>(new int[Population.ValidColors+1]);
            foreach (var list in input)
            {
                counts[list[pos]]++;
            }

            return counts.IndexOf(counts.Max());
        }

        public static List<int> WisdomOfCrowds(this Population population)
        {
            var expertChromosomes = population.GetTopHalf();
            var aggregateChromosome = population.GetBest();

            for (var i = 0; i < aggregateChromosome.Count; i++)
            {
                var badEdge = false;
                for (var j = 0; j < aggregateChromosome.Count; j++)
                    if (Population.Adjacency[i, j] == 1 && aggregateChromosome[i] == aggregateChromosome[j])
                        badEdge = true;

                if (badEdge)
                    aggregateChromosome[i] = MostUsed(expertChromosomes, i);

            }

            return aggregateChromosome;
        }

        public static int UsedColors(this List<int> chromosome)
        {
            if (chromosome == null)
                return 999999;
            var allColors = new List<int>();
            foreach (var i in chromosome)
                if (!allColors.Contains(i))
                    allColors.Add(i);
            return allColors.Count;
        }
    }
}