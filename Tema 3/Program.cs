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
        }
    }
}