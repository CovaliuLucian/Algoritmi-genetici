using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Functions;
using Tema_2.Selections;

namespace Tema_2
{
    internal partial class Program
    {
        public static List<double> Run(int dimensions, ISelection selector, IFunction function, int populationSize,
            int iterations = 15)
        {
            var results = new List<double>();

            for (var i = 0; i < iterations; i++)
                results.Add(Math.Round(Minimum.GetMinimum(function, selector, dimensions, populationSize), 4));

            return results;
        }

        private static async Task<List<double>> RunAsync(int dimensions, ISelection selector, IFunction function,
            int populationSize, int iterations = 15)
        {
            var results = new List<double>();

            for (var i = 0; i < iterations; i++)
                await Task.Run(() =>
                {
                    results.Add(Math.Round(Minimum.GetMinimum(function, selector, dimensions, populationSize), 4));
                });
            return results;
        }

        private static void Run(bool toFile = true)
        {
            if (toFile)
            {
                using (var writer = File.CreateText("Raw Data.txt"))
                {
                    writer.AutoFlush = true;
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    var results = RunAsync(5, new Tourney(), new DeJong1(), 100).Result;
                    writer.WriteLine("DeJong on 5 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: 0");

                    results = RunAsync(10, new Tourney(), new DeJong1(), 100).Result;
                    writer.WriteLine("DeJong on 10 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: 0");

                    results = RunAsync(30, new Tourney(), new DeJong1(), 100).Result;
                    writer.WriteLine("DeJong on 30 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: 0");

                    Console.WriteLine("DeJong Done.");
                    Console.WriteLine("It took " + stopwatch.Elapsed);

                    writer.WriteLine("It took " + stopwatch.Elapsed + " for these.");
                    stopwatch.Restart();


                    results = RunAsync(5, new Tourney(), new Schwefel(), 2000).Result;
                    writer.WriteLine("Schwefel on 5 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: " + -418.9819 * 5);

                    results = RunAsync(10, new Tourney(), new Schwefel(), 2500).Result;
                    writer.WriteLine("Schwefel on 10 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: " + -418.9819 * 10);

                    results = RunAsync(30, new Tourney(), new Schwefel(), 3000).Result;
                    writer.WriteLine("Schwefel on 30 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: " + -418.9819 * 30);

                    Console.WriteLine("Schwefel Done.");
                    Console.WriteLine("It took " + stopwatch.Elapsed);

                    writer.WriteLine("It took " + stopwatch.Elapsed + " for these.");
                    stopwatch.Restart();


                    results = RunAsync(2, new Tourney(), new SixHump(), 1000).Result;
                    writer.WriteLine("Six Hump on 2 dimensions(max): ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: -1.0316");

                    Console.WriteLine("SixHump Done.");
                    Console.WriteLine("It took " + stopwatch.Elapsed);


                    writer.WriteLine("It took " + stopwatch.Elapsed + " for these.");
                    stopwatch.Restart();


                    results = RunAsync(5, new Tourney(), new Rastrigin(), 2000).Result;
                    writer.WriteLine("Rastrigin on 5 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: 0");

                    results = RunAsync(10, new Tourney(), new Rastrigin(), 2500).Result;
                    writer.WriteLine("Rastrigin on 10 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: 0");

                    results = RunAsync(30, new Tourney(), new Rastrigin(), 3000).Result;
                    writer.WriteLine("Rastrigin on 30 dimensions: ");
                    results.ForEach(number => writer.WriteLine(number));
                    writer.WriteLine("Average: " + results.Average());
                    writer.WriteLine("Correct: 0");

                    Console.WriteLine("Rastrigin Done.");
                    Console.WriteLine("It took " + stopwatch.Elapsed);
                }
            }
            else
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var results = RunAsync(5, new Tourney(), new DeJong1(), 100).Result;
                Console.WriteLine("DeJong on 5 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: 0");

                results = RunAsync(10, new Tourney(), new DeJong1(), 100).Result;
                Console.WriteLine("DeJong on 10 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: 0");

                results = RunAsync(30, new Tourney(), new DeJong1(), 100).Result;
                Console.WriteLine("DeJong on 30 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: 0");


                Console.WriteLine("It took " + stopwatch.Elapsed + " for these.");
                stopwatch.Restart();


                results = RunAsync(5, new Tourney(), new Schwefel(), 2000).Result;
                Console.WriteLine("Schwefel on 5 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: " + -418.9819 * 5);

                results = RunAsync(10, new Tourney(), new Schwefel(), 2500).Result;
                Console.WriteLine("Schwefel on 10 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: " + -418.9819 * 10);

                results = RunAsync(30, new Tourney(), new Schwefel(), 3000).Result;
                Console.WriteLine("Schwefel on 30 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: " + -418.9819 * 30);


                Console.WriteLine("It took " + stopwatch.Elapsed + " for these.");
                stopwatch.Restart();


                results = RunAsync(2, new Tourney(), new SixHump(), 1000).Result;
                Console.WriteLine("Six Hump on 2 dimensions(max): ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: -1.0316");


                Console.WriteLine("It took " + stopwatch.Elapsed + " for these.");
                stopwatch.Restart();


                results = RunAsync(5, new Tourney(), new Rastrigin(), 2000).Result;
                Console.WriteLine("Rastrigin on 5 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: 0");

                results = RunAsync(10, new Tourney(), new Rastrigin(), 2500).Result;
                Console.WriteLine("Rastrigin on 10 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: 0");

                results = RunAsync(30, new Tourney(), new Rastrigin(), 3000).Result;
                Console.WriteLine("Rastrigin on 30 dimensions: ");
                results.ForEach(Console.WriteLine);
                Console.WriteLine("Average: " + results.Average());
                Console.WriteLine("Correct: 0");
            }
        }
    }
}