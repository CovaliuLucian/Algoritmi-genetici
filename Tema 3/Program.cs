using System;
using Tema_3.Mutations;

namespace Tema_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = GeneticAlgorithm.Run(20000, 50);
            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nFitness: " + result.Fitness());
            Console.WriteLine("It used {0} colors",result.UsedColors());
        }
    }
}