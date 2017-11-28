using System;
using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2.Selections
{
    public class Tourney : ISelection
    {
        public Population Select(Population population, IFunction function)
        {
            var dictionary = new Dictionary<double, List<string>>();
            var toReturn = new List<List<string>>();
            while (true)
            {
                var k = population.ValueList.Count / 10;
                var j = Math.Max(k / 2, population.ValueList.Count - toReturn.Count);
                var randoms = new Population(new List<List<string>>());

                while (k > 0)
                {
                    k--;
                    var pos = Genetics.GetRandom(0, population.ValueList.Count);
                    randoms.ValueList.Add(population.ValueList[pos]);
                }

                var evaluated = randoms.Evaluate(function);
                for (var i = 0; i < evaluated.Count; i++)
                    dictionary.Add(evaluated[i], population.ValueList[i]);

                var orderedList = dictionary.OrderBy(x => x.Value).ToList();
                foreach (var pair in orderedList)
                {
                    if (j > 0)
                        toReturn.Add(pair.Value);
                    j--;
                }

                if (toReturn.Count == population.ValueList.Count)
                    break;
            }
            return new Population(toReturn);
        }
    }
}