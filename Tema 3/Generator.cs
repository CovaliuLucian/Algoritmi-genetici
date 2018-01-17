using System.Collections.Generic;

namespace Tema_3
{
    public static class Generator
    {
        public static Population Generate(int size = 1)
        {
            var population = new Population(size) {ValueList = new List<List<int>>(size)};
            for (var i = 0; i < size; i++)
            {
                population.ValueList.Add(new List<int>());
                for (var j = 0; j < Population.Vertices; j++)
                    population.ValueList[i].Add(Genetics.GetRandom(0, Population.ValidColors + 1));
            }
            return population;
        }
    }
}