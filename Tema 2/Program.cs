using System;

namespace Tema_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //for (var i = 0; i < 200; i++)
            //{
            //    var test = Genetics.GetRandom(0, (int)Math.Pow(2,30));
            //    Console.WriteLine(test.ToBinary());
            //    Console.WriteLine(test.ToBinary().Mutate()+"\n");
            //}
            Console.WriteLine(65535.ToBinary());
            Console.WriteLine(0.ToBinary());
            foreach (var s in Genetics.CrossOver(65535.ToBinary(), 0.ToBinary()))
            {
                Console.Write(s+"\n");
            }
            var a = Genetics.CrossOver(65535.ToBinary(), 0.ToBinary());
            a.CrossOver();
            foreach (var s in a)
            {
                Console.Write(s + "\n");
            }
        }
    }
}