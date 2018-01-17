using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var watch = new Stopwatch();
            watch.Start();

            while (i < runs && population.GetBestColored().UsedColors() != 5)
            {
                var parents = selection.Select(population);
                var child = parents.CrossOver();
                child = mutation.Mutate(child);

                population.ValueList = population.GetTopHalf();
                population.ValueList.Add(child);
                population.ReGenerate();

                if (!phaseTwo)
                {
                    if (population.GetBest().Conflicts() <= 4)
                    {
                        selection = new Selector2();
                        mutation = new Mutation2();
                        phaseTwo = true;
                    }
                }
                else
                {
                    if (population.GetBest().Conflicts() > 5)
                    {
                        selection = new Selector1();
                        mutation = new Mutation1();
                        phaseTwo = false;
                    }
                }

                if (i % 500 == 0)
                    Console.WriteLine(i);

                i++;
            }

            Console.WriteLine(watch.Elapsed);
            watch.Stop();

            return population.GetBestColored().Conflicts() == 0
                ? population.GetBestColored()
                : population.WisdomOfCrowds();
        }
    }
}