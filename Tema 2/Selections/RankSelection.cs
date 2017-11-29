using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2.Selections
{
    public class RankSelection : ISelection
    {
        public Population Select(Population population, IFunction function)
        {
            var orderedPopulation =
                new Population(population.ValueList.OrderBy(list => list.Evaluate(function)).Reverse().ToList());
            var toReturn = new List<List<string>>();
            while (toReturn.Count != population.ValueList.Count)
                for (var i = 0; i < orderedPopulation.ValueList.Count; i++)
                {
                    if (toReturn.Count == population.ValueList.Count)
                        break;
                    if (i < 0.05 * orderedPopulation.ValueList.Count) // Elitism
                    {
                        toReturn.Add(orderedPopulation.ValueList[i]);
                        continue;
                    }
                    if (Genetics.GetByChance(((double) orderedPopulation.ValueList.Count - i) /
                                             orderedPopulation.ValueList.Count / 2))
                        toReturn.Add(orderedPopulation.ValueList[i]);
                }

            return new Population(toReturn);
        }
    }
}