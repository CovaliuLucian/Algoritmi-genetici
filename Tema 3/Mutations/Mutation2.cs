using System;
using System.Collections.Generic;
using System.Linq;

namespace Tema_3.Mutations
{
    public class Mutation2 : IMutation
    {
        public List<int> Mutate(List<int> chromosome)
        {
            var allColors = new List<int>();
            foreach (var i in chromosome)
                if (!allColors.Contains(i))
                    allColors.Add(i);

            for (var i = 0; i < chromosome.Count; i++)
            {
                var adjList = chromosome.Where((t, j) => Population.Adjacency[i, j] == 1 && chromosome[i] == t)
                    .ToList();

                if (adjList.Count == 0) continue;

                chromosome[i] = allColors[Genetics.GetRandom(0, allColors.Count)];
            }

            return chromosome;
        }
    }
}