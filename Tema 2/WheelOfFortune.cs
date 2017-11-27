using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2
{
    public static class WheelOfFortune
    {
        public static Population Select(this Population population, IFunction function)
        {
            var evaluated = population.Evaluate(function);

            var total = evaluated.Sum();

            var individual = evaluated.Select(x => x / total).ToList();

            var relative = new List<double> { 0 };
            for (var i = 1; i < individual.Count; i++)
                relative.Add(individual[i] + relative[i - 1]);

            var toReturn = relative.Select(t => Genetics.GetRandom()).Select(random => population.ValueList[relative.IndexOf(relative.Where((value, j) => value < random && random <= relative[j + 1]).ToList()[0])]).ToList();

            //foreach (var t in relative)
            //{
            //    var random = Genetics.GetRandom();
            //    //for (var j = 0; j < relative.Count; j++)
            //    //{
            //    //    if (relative[j] < random && random <= relative[j + 1])
            //    //        toReturn.Add(population.ValueList[j]);
            //    //}

            //    toReturn.Add(population.ValueList[relative.IndexOf(relative.Where((value, j) =>
            //        value < random && random <= relative[j + 1]
            //    ).ToList()[0])]);
            //}

            return new Population(toReturn);
        }
    }
}