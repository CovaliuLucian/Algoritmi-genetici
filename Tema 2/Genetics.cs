using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using Functions;
using Tema_2.Exceptions;

namespace Tema_2
{
    public static class Genetics
    {
        private static readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());
        private static MemoryCache _cache = new MemoryCache("Names");

        public static int GetRandom(int min, int max)
        {
            return RandomGenerator.Next(min, max);
        }

        public static double GetRandom()
        {
            return RandomGenerator.NextDouble() * (1 - double.Epsilon) + double.Epsilon;
        }

        public static bool GetByChance(double chance)
        {
            if (chance > 1 || chance < 0)
                throw new InvalidArgsException();
            return RandomGenerator.NextDouble() <= chance;
        }

        public static char Not(this char c)
        {
            return c == '0' ? '1' : '0';
        }

        public static string ToBinary(this int number)
        {
            return Convert.ToString(number, 2).PadLeft(32, number >= 0 ? '0' : '1');
        }

        public static string ToBinary(this double number, int precisionQuantifier = 1000)
        {
            return Convert.ToString((int) Math.Floor(number * precisionQuantifier), 2)
                .PadLeft(32, number >= 0 ? '0' : '1');
        }

        public static List<string> ToBinary(this List<double> numbers, int precisionQuantifier = 1000)
        {
            return numbers.Select(number => number.ToBinary(precisionQuantifier)).ToList();
        }

        public static int ToInt(this string number)
        {
            return Convert.ToInt32(number, 2);
        }

        public static double ToDouble(this string number, int precisionQuantifier = 1000)
        {
            return (double) number.ToInt() / precisionQuantifier;
        }

        public static List<double> ToDouble(this List<string> numbers, int precisionQuantifier = 1000)
        {
            return numbers.Select(number => number.ToDouble(precisionQuantifier)).ToList();
        }

        public static string Mutate(this string number, double min = double.NegativeInfinity,
            double max = double.PositiveInfinity)
        {
            var position = GetRandom(0, 31);
            var builder = new StringBuilder(number);
            builder[position] = builder[position].Not();
            var toReturn = builder.ToString();

            while (toReturn.ToDouble() < min || toReturn.ToDouble() > max)
                toReturn = Mutate(number);
            return toReturn;
        }

        public static List<string> Mutate(this List<string> numbers, double min = double.NegativeInfinity,
            double max = double.PositiveInfinity)
        {
            var pos = GetRandom(0, numbers.Count);
            numbers[pos] = numbers[pos].Mutate(min, max);
            return numbers;
            //return numbers.Select(number => number.Mutate(min, max)).ToList();
        }

        public static Population Mutate(this Population population, double chance = 0.01,
            double min = double.NegativeInfinity, double max = double.PositiveInfinity)
        {
            return new Population(population.ValueList
                .Select(numbers => GetByChance(chance) ? numbers.Mutate(min, max) : numbers).ToList());
        }

        public static Population Mutate(this Population population, IFunction function, double chance = 0.1)
        {
            return Mutate(population, chance, (double) function.SearchMinimum, (double) function.SearchMaximum);
        }

        public static List<string> CrossOver(string firstNumber, string secondNumber,
            double min = double.NegativeInfinity, double max = double.PositiveInfinity)
        {
            var position = GetRandom(0, 31);
            var toReturn = new List<string>
            {
                firstNumber.Substring(0, position) + secondNumber.Substring(position),
                secondNumber.Substring(0, position) + firstNumber.Substring(position)
            };
            while (toReturn[0].ToDouble() < min || toReturn[0].ToDouble() > max || toReturn[1].ToDouble() < min ||
                   toReturn[1].ToDouble() > max)
                toReturn = CrossOver(firstNumber, secondNumber);
            return toReturn;
        }

        public static List<string> CrossOver2(string firstNumber, string secondNumber,
            double min = double.NegativeInfinity, double max = double.PositiveInfinity)
        {
            var first = new StringBuilder();
            var second = new StringBuilder();

            for (var i = 0; i < 32; i++)
                if (GetByChance(0.5))
                {
                    first.Append(firstNumber[i]);
                    second.Append(secondNumber[i]);
                }
                else
                {
                    first.Append(secondNumber[i]);
                    second.Append(firstNumber[i]);
                }

            var toReturn = new List<string> {first.ToString(), second.ToString()};
            while (toReturn[0].ToDouble() < min || toReturn[0].ToDouble() > max || toReturn[1].ToDouble() < min ||
                   toReturn[1].ToDouble() > max)
                toReturn = CrossOver(firstNumber, secondNumber);
            return toReturn;
        }

        public static Population CrossOver(this Population population, double chance = 0.1,
            double min = double.NegativeInfinity, double max = double.PositiveInfinity)
        {
            var toReturn = new List<List<string>>();
            var first = true;
            List<string> temp = null;

            for (var index = 0; index < population.ValueList.Count; index++)
            {
                var list = population.ValueList[index];
                if (GetByChance(chance))
                    if (first)
                    {
                        if (index == population.ValueList.Count)
                        {
                            toReturn.Add(list);
                        }
                        else
                        {
                            temp = list;
                            first = false;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < list.Count; i++)
                        {
                            var crossed = CrossOver(temp[i], list[i], min, max);
                            temp[i] = crossed[0];
                            list[i] = crossed[1];
                        }
                        first = true;
                        toReturn.Add(temp);
                        toReturn.Add(list);
                    }
                else
                    toReturn.Add(list);
            }

            if (!first)
                toReturn.Add(temp);

            return new Population(toReturn);
        }

        public static Population CrossOver(this Population population, IFunction function, double chance = 0.1)
        {
            return CrossOver(population, chance, (double) function.SearchMinimum, (double) function.SearchMaximum);
        }

        public static double HammingDistance(List<string> number1, List<string> number2)
        {
            var distance = 0;
            var count = 0;
            for (var i = 0; i < number1.Count; i++)
            {
                count++;
                distance += HammingDistance(number1[i], number2[i]);
            }
            return (double) distance / count;
        }

        public static int HammingDistance(string number1, string number2)
        {
            return number1.Zip(number2, (l, r) => l - r == 0 ? 0 : 1).Sum();
        }

        public static double HammingDistance(this Population population)
        {
            var first = population.ValueList.First();
            return population.ValueList.Where(list => !list.Equals(first)).Sum(list => HammingDistance(first, list)) /
                   population.ValueList.Count;
        }

        public static double StandardDeviation(this Population population, IFunction function)
        {
            var average = population.ValueList.Average(list => function.Calculate(list.ToDouble()));
            var s = population.ValueList.Sum(list => Math.Pow(function.Calculate(list.ToDouble()) - average, 2));
            return Math.Sqrt(s / (population.ValueList.Count - 1));
        }
    }
}