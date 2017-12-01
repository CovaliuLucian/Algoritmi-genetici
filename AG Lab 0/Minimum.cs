using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Functions;

namespace AG_Lab_0
{
    internal class Minimum
    {
        private static decimal _accuracy = (decimal) 0.1;
        private static readonly decimal Lenght = 1;
        private static readonly decimal BestImprovement = (decimal) 0.0001;

        private static int _iterations = 1000; // more or less

        private static int _maximumSearches = 1000;

        private static readonly Stopwatch StopWatch = new Stopwatch();

        private static List<decimal> _listOfArgs;
        private static decimal _min;
        private static int _lastCounter;

        private static decimal GetRandom(decimal min, decimal max)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return Convert.ToDecimal(random.NextDouble()) * (max - min) + min;
        }

        public static List<decimal> SetListOfArgs(IFunction function, int dimensions)
        {
            var listOfArgs = new List<decimal>();

            for (var i = 0; i < dimensions; i++)
                listOfArgs.Add(GetRandom(function.SearchMinimum, function.SearchMaximum));

            return listOfArgs;
        }

        public static void SetParameters(int iterations = 1000, int maximumSearches = 1000,
            decimal accuracy = (decimal) 0.1)
        {
            _iterations = iterations;
            _maximumSearches = maximumSearches;
            _accuracy = accuracy;
        }

        public static void CountTime()
        {
            if (!StopWatch.IsRunning)
            {
                StopWatch.Start();
            }
            else
            {
                Console.WriteLine("It took: " + StopWatch.Elapsed + "\n");
                StopWatch.Stop();
                StopWatch.Reset();
            }
        }

        private static decimal Explore(IFunction function, List<decimal> list, int dimension)
        {
            var min = function.Calculate(list);
            var best = list[dimension];
            for (var i = list[dimension] - Lenght > function.SearchMinimum
                    ? list[dimension] - Lenght
                    : function.SearchMinimum;
                i < list[dimension] + Lenght && i < function.SearchMaximum;
                i += _accuracy)
            {
                list[dimension] = i;
                var newmin = function.Calculate(list);
                if (newmin >= min) continue;
                min = newmin; // best
                if (function.Counter - 20000 > _lastCounter)
                {
                    Tracer.Counter(function, min);
                    _lastCounter = function.Counter;
                }
                best = i;
                //return list[dimension]; // first
            }
            return best;
        }

        private static void CalculateMinimumHillClimb(IFunction function, int dimensions)
        {
            var totalCounter = 0;
            Console.WriteLine();

            for (var i = 0; i < dimensions; i++)
            for (var count = 0; count < _maximumSearches; count++)
            {
                var newList = _listOfArgs.ToList();
                newList[i] = Explore(function, _listOfArgs.ToList(), i);

                if (function.Counter > 1000 || totalCounter == 0)
                {
                    totalCounter += function.Counter;
                    Console.WriteLine(function.GetName() + " " + totalCounter + " at " +
                                      Math.Round(function.Calculate(_listOfArgs), 4));
                    function.Counter = 0;
                }

                var exploredValue = function.Calculate(newList);
                if (exploredValue < function.Calculate(_listOfArgs) &&
                    exploredValue + BestImprovement < function.Calculate(_listOfArgs))
                    _listOfArgs = newList;
                else
                    break;
            }

            var newmin = function.Calculate(_listOfArgs);
            if (newmin < _min)
                _min = newmin;
        }

        private static void CalculateMinimumOld(IFunction function, int dimensions)
        {
            for (var i = 0; i < dimensions; i++)
            for (var count = 0; count < _maximumSearches; count++)
            {
                var leftList = _listOfArgs.ToList();
                var rightList = _listOfArgs.ToList();
                leftList[i] -= _accuracy;
                rightList[i] += _accuracy;
                if (function.Calculate(leftList) > function.Calculate(_listOfArgs) &&
                    function.Calculate(rightList) > function.Calculate(_listOfArgs))
                    break;
                _listOfArgs = function.Calculate(leftList) < function.Calculate(rightList) ? leftList : rightList;
            }

            var newmin = function.Calculate(_listOfArgs);
            if (newmin < _min)
                _min = newmin;
        }

        private static void CalculateMinimumAnnealing(IFunction function, int dimensions)
        {
            decimal T = 100;

            for (var i = 0; i < dimensions; i++)
            for (var count = 0; count < _maximumSearches; count++)
            {
                var newList = _listOfArgs.ToList();
                newList[i] = Explore(function, _listOfArgs.ToList(), i);
                var exploredValue = function.Calculate(newList);
                if (exploredValue < function.Calculate(_listOfArgs) &&
                    exploredValue + BestImprovement < function.Calculate(_listOfArgs))
                {
                    _listOfArgs = newList;
                }
                else
                {
                    var r = GetRandom(0, 1);
                    if (r < (decimal) Math.Exp(
                            -Math.Abs((double) (exploredValue - function.Calculate(_listOfArgs)))) / T)
                        T = T * (decimal) (1 - 0.03);
                    else
                        break;
                }
            }

            var newmin = function.Calculate(_listOfArgs);
            if (newmin < _min)
                _min = newmin;
        }

        public static async Task<decimal> GetMinimum(IFunction function, int dimensions)
        {
            CountTime();

            _lastCounter = 0;

            _listOfArgs = SetListOfArgs(function, dimensions);

            _min = function.Calculate(_listOfArgs);

            for (var count = 0; count < _iterations; count++)
                await Task.Run(() =>
                {
                    // CalculateMinimumOld(function, dimensions); // my thing
                    CalculateMinimumHillClimb(function, dimensions); // hillclimb
                    //CalculateMinimumAnnealing(function, dimensions); // annealing
                });

            return _min;
        }
    }
}