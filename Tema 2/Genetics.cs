using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tema_2.Exceptions;

namespace Tema_2
{
    public static class Genetics
    {
        private static readonly Random RandomGenerator = new Random(Guid.NewGuid().GetHashCode());

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

        public static string ToBinary(this double number, int precisionQuantifier = 10000)
        {
            return Convert.ToString((int)Math.Floor(number*precisionQuantifier), 2).PadLeft(32, number >= 0 ? '0' : '1');
        }

        public static List<string> ToBinary(this List<double> numbers, int precisionQuantifier = 10000)
        {
            return numbers.Select(number => number.ToBinary(precisionQuantifier)).ToList();
        }

        public static int ToInt(this string number)
        {
            return Convert.ToInt32(number, 2);
        }

        public static double ToDouble(this string number, int precisionQuantifier=10000)
        {
            return (double) number.ToInt() / precisionQuantifier;
        }

        public static List<double> ToDouble(this List<string> numbers, int precisionQuantifier = 10000)
        {
            return numbers.Select(number => number.ToDouble(precisionQuantifier)).ToList();
        }

        public static string Mutate(this string number)
        {
            var position = GetRandom(0, 31);
            var builder = new StringBuilder(number);
            builder[position] = builder[position].Not();
            return builder.ToString();
        }

        public static List<string> Mutate(this IList<string> numbers)
        {
            return numbers.Select(number => number.Mutate()).ToList();
        }

        public static List<string> CrossOver(string firstNumber, string secondNumber)
        {
            var position = GetRandom(0, 31);
            Console.WriteLine(position);
            return new List<string>
            {
                firstNumber.Substring(0, position) + secondNumber.Substring(position),
                secondNumber.Substring(0, position) + firstNumber.Substring(position)
            };
        }

        public static void CrossOver(this IList<string> numbers)
        {
            var newList = new List<string>();
            while (numbers.Count > 0)
            {
                if (numbers.Count != 1)
                {
                    var random1 = GetRandom(0, numbers.Count);

                    var number1 = numbers[random1];
                    numbers.RemoveAt(random1);

                    var random2 = GetRandom(0, numbers.Count);
                    var newNumbers = CrossOver(number1, numbers[random2]);

                    newList.Add(newNumbers[0]);
                    newList.Add(newNumbers[1]);

                    numbers.RemoveAt(random2);
                }
                else
                {
                    numbers.RemoveAt(0);
                    newList.Add(numbers[0]);
                    break;
                }
            }
            if (numbers.Count != 0)
                throw new InvalidExpressionException("What the fuck");

            newList.ForEach(numbers.Add);
        }

        public static double HammingDistance(List<string> number1, List<string> number2)
        {
            var minCount = Math.Min(number1.Count,number2.Count);
            var distance = 0;
            var count = 0;
            for (var i = 0; i < minCount; i++)
            {
                var hammingDistance = HammingDistance(number1[i], number2[i]);
                if (hammingDistance == 0) continue;
                count++;
                distance += hammingDistance;
            }
            return (double)distance/count;
        }

        public static int HammingDistance(string number1, string number2)
        {
            var minCount = Math.Min(number1.Length, number2.Length);
            var distance = 0;
            for (var i = 0; i < minCount; i++)
                if (number1[i] != number2[i])
                    distance++;
            return distance;
        }

        //public static List<string> SelectByChance(Population population, double chance)
        //{
        //    var a = population.ValueList.FindAll(x =>
        //        GetByChance(chance)
        //    ).ToList();
        //}
    }
}