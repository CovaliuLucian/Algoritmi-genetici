using System;
using System.Diagnostics;
using System.Linq;
using Functions;
using Tema_2.Selections;

namespace Tema_2
{
    public static class Minimum
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        public static TimeSpan GetTime()
        {
            return Stopwatch.Elapsed;
        }

        private static double MinimOfPopulation(this Population population, IFunction function)
        {
            return population.ValueList.Min(list => function.Calculate(list.ToDouble()));
        }

        public static double GetMinimum(IFunction function,ISelection selector, int dimensions, int size, double crossChance = 0.1, double mutationChance=0.01)
        {
            Stopwatch.Restart();
            var population = Generator.GeneratePopulation(dimensions, function, size);
            var maxIterations = 1000;
            while (population.HammingDistance() > 0 && maxIterations > 0)
            {
                maxIterations--;
                population = selector.Select(population, function);
                population = population.CrossOver(function, crossChance);
                population = population.Mutate(function, mutationChance);
            }
            //population.Write();
            //Console.WriteLine(population.ValueList.Count);
            return population.MinimOfPopulation(function);
        }
    }
}