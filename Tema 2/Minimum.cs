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

        public static double GetMinimum(IFunction function, ISelection selector, int dimensions, int size,
            double crossChance = 0.7, double mutationChance = 0.5)
        {
            Stopwatch.Restart();
            var population = Generator.GeneratePopulation(dimensions, function, size);
            const int maxIterations = 1000;
            var count = 0;
            var minimum = population.MinimOfPopulation(function);
            //while (population.HammingDistance() > 2 && count != maxIterations)
            while (population.StandardDeviation(function) > 1 && count != maxIterations)
            {
                count++;
                //if (count%1000 == 0 && count > 0)
                //    Console.WriteLine("Count= " + count);

                population = selector.Select(population, function);
                population = population.Mutate(function, mutationChance);
                population = population.CrossOver(function, crossChance);

                //var newMin = population.MinimOfPopulation(function);
                //if (minimum > newMin)
                //    minimum = newMin;
            }
            //population.Write();
            //Console.WriteLine(population.HammingDistance() + "\n");
            Console.WriteLine(population.StandardDeviation(function) + "\n");
            minimum = population.MinimOfPopulation(function);
            //population.Write();
            return minimum;
        }
    }
}