using System;
using Tema_3.Mutations;

namespace Tema_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = GeneticAlgorithm.Run(2000, 50);
            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nFitness: " + result.Fitness());
            Console.WriteLine("It used {0} colors",result.UsedColors());


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            //result = GeneticAlgorithm.bestEver;
            //foreach (var i in result)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine("\nFitness: " + result.Fitness());
            //Console.WriteLine("It used {0} colors", result.UsedColors());

            Console.Write("Greedy:\n");
            var greedy = Heuristic.Greedy();
            foreach (var i in greedy)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nFitness: " + greedy.Fitness());
            Console.WriteLine("It used {0} colors", greedy.UsedColors());


            Console.Write("\nGreedy with Largest degree ordering (LDO):\n");
            greedy = Heuristic.GreedyLdo();
            foreach (var i in greedy)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nFitness: " + greedy.Fitness());
            Console.WriteLine("It used {0} colors", greedy.UsedColors());

            Console.Write("\nGreedy with Saturation degree ordering (SDO):\n");
            greedy = Heuristic.GreedyLdo();
            foreach (var i in greedy)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nFitness: " + greedy.Fitness());
            Console.WriteLine("It used {0} colors", greedy.UsedColors());
        }
    }
}