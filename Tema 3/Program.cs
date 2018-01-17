using System;

namespace Tema_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var population = Generator.Generate(10);
            population.WriteAdjacency();
            Console.WriteLine();
            population.WriteValueList();

            Console.WriteLine();

            var p = new Population {ValueList = population.GetTopHalf()};
            p.WriteValueList();

            Console.WriteLine();

            p = new Population { ValueList = population.GetBottomHalf()};
            p.WriteValueList();

            Console.WriteLine();

            Console.WriteLine(population.GetMinimumFitness());
        }
    }
}