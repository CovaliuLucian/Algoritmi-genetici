using System;
using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2_Prim.Selectors
{
    public class Tourney : ISelection
    {
        public Population Select(Population population, IFunction function)
        {
            var toReturn = new List<List<string>>();
            while (true)
            {
                var k = population.ValueList.Count / 10;
                var j = Math.Min(k / 2, population.ValueList.Count - toReturn.Count);
                var randoms = new Population(new List<List<string>>());

                while (k > 0)
                {
                    k--;
                    var pos = Genetics.GetRandom(0, population.ValueList.Count);
                    randoms.ValueList.Add(population.ValueList[pos].ToList());
                }

                var orderedPopulation =
                    new Population(randoms.ValueList.OrderBy(list => list.Evaluate(function)).Reverse().ToList());

                foreach (var list in orderedPopulation.ValueList)
                {
                    if (j > 0)
                        toReturn.Add(list);
                    j--;
                }

                if (toReturn.Count == population.ValueList.Count)
                    break;
            }
            return new Population(toReturn);
        }
    }
}