using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2_Prim.Selectors
{
    public class WheelOfFortune : ISelection
    {
        public Population Select(Population population, IFunction function)
        {
            var evaluated = population.Evaluate(function);

            var total = evaluated.Sum();

            var individual = evaluated.Select(x => x / total).ToList();

            var relative = new List<double> {0};
            for (var i = 1; i < individual.Count; i++)
                relative.Add(individual[i] + relative[i - 1]);

            //var toReturn = relative.Select(t => Genetics.GetRandom()).Select(random => population.ValueList[relative.IndexOf(relative.Where((value, j) => j == relative.Count - 1
            //    ? value < random && random <= 1
            //    : value < random && random <= relative[j + 1]).ToList()[0])]).ToList();

            var toReturn = new List<List<string>>();

            foreach (var unused in relative)
            {
                var random = Genetics.GetRandom();
                for (var j = 0; j < relative.Count; j++)
                {
                    if (j == relative.Count - 1)
                    {
                        if (relative[j] < random && random <= 1)
                            toReturn.Add(population.ValueList[j].ToList());
                        break;
                    }

                    if (!(relative[j] < random) || !(random <= relative[j + 1])) continue;
                    toReturn.Add(population.ValueList[j].ToList());
                    break;
                }
            }

            return new Population(toReturn);
        }
    }
}