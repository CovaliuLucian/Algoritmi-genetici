using System.Collections.Generic;
using Tema_3.Mutations;
using Tema_3.Selections;

namespace Tema_3
{
    public static class GeneticAlgorithm
    {
        public static List<int> Run(int runs, int size)
        {
            var population = Generator.Generate(size);
            ISelection selection = new Selector1();
            IMutation mutation = new Mutation1();

            var i = 0;
            var phaseTwo = false;

            while (i < runs)
            {
                var parents = selection.Select(population);
                var child = parents.CrossOver();
                child = mutation.Mutate(child);

                population.ValueList = population.GetTopHalf();
                population.ValueList.Add(child);
                population.ReGenerate();


                if (population.GetBest().Conflicts() <= 2 && !phaseTwo)
                {
                    selection = new Selector2();
                    mutation = new Mutation2();
                    phaseTwo = true;
                }


                i++;
            }

            return population.GetBestColored().Conflicts() == 0
                ? population.GetBestColored()
                : population.WisdomOfCrowds();
        }
    }
}