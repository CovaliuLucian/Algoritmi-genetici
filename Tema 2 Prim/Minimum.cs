using System;
using System.Diagnostics;
using System.Linq;
using Functions;
using Tema_2_Prim.Selectors;

namespace Tema_2_Prim
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
            double crossChance = 0.5, double mutationChance = 0.3)
        {
            function.Counter = 0;
            Stopwatch.Restart();
            var population = Generator.GeneratePopulation(dimensions, function, size);
            const int maxIterations = 1000;
            var count = 0;
            var timesForBreak = 5;
            var lastMinimum = population.MinimOfPopulation(function);
            //while (population.HammingDistance() > 2 && count != maxIterations)
            while (count != maxIterations)
            {
                count++;
                if (count % 10 == 0)
                {
                    var currentMinimum = population.MinimOfPopulation(function);
                    if (Math.Abs(currentMinimum - lastMinimum) < 0.00001)
                        if (timesForBreak == 0)
                            break;
                        else
                            timesForBreak--;
                    else
                        lastMinimum = currentMinimum;
                }

                population = selector.Select(population, function);
                population = population.Mutate(function, mutationChance);
                population = population.CrossOver(function, crossChance);
            }
            //population.Write();
            //Console.WriteLine(population.HammingDistance() + "\n");
            //Console.WriteLine(population.StandardDeviation(function) + "\n");
            
            return population.MinimOfPopulation(function);
        }
    }
}