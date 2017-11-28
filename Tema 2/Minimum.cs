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

        public static double GetMinimum(IFunction function,ISelection selector, int dimensions, int size, double crossChance = 0.4, double mutationChance=0.1)
        {
            Stopwatch.Restart();
            var population = Generator.GeneratePopulation(dimensions, function, size);
            const int maxIterations = 3000;
            var count = 0;
            var minimum = population.MinimOfPopulation(function);
            while (population.HammingDistance() > -2 && count!=maxIterations)
            {
                count++;
                if(count%1000 == 0)
                    Console.WriteLine("At " + count + " iterations.");
                population = selector.Select(population, function);
                population = population.CrossOver(function, crossChance);
                population = population.Mutate(function, mutationChance);

                var newMin = population.MinimOfPopulation(function);
                if (minimum > newMin)
                    minimum = newMin;
            }
            Console.WriteLine(population.HammingDistance());
            minimum = population.MinimOfPopulation(function);
            //population.Write();
            return minimum;
        }
    }
}