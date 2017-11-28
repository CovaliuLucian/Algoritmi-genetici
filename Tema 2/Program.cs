using System;
using Functions;
using Tema_2.Selections;

namespace Tema_2
{
    internal class Program
    {
        private static void Main()
        {
            //for (var i = 0; i < 200; i++)
            //{
            //    var test = Genetics.GetRandom(0, (int)Math.Pow(2,30));
            //    Console.WriteLine(test.ToBinary());
            //    Console.WriteLine(test.ToBinary().Mutate()+"\n");
            //}

            //var test = Generator.GeneratePopulation(5, -5.12, 5.12, 5);
            //test.ValueList.ForEach(x =>
            //{
            //    x.ForEach((b) => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            //var evaluated = test.Evaluate(new DeJong1());
            //evaluated.ForEach(x =>
            //{
            //    Console.Write(x + " ");
            //});
            //Console.WriteLine();

            //var wheel = new WheelOfFortune();

            //var wheeled = wheel.Select(test,new DeJong1());
            //wheeled.ValueList.ForEach(x =>
            //{
            //    x.ForEach(b => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            //Console.WriteLine();
            //var crossed = wheeled.CrossOver();
            //crossed.ValueList.ForEach(x =>
            //{
            //    x.ForEach(b => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            //Console.WriteLine();
            //var mutated = wheeled.Mutate(0.5,-5.12,5.12);
            //mutated.ValueList.ForEach(x =>
            //{
            //    x.ForEach(b => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            Console.WriteLine("De Jong: " + Minimum.GetMinimum(new DeJong1(), new Tourney(), 2, 100) + "\nCorrect: 0");
            Console.WriteLine("It took " + Minimum.GetTime());

            Console.WriteLine("\nSchwefel: " + Minimum.GetMinimum(new Schwefel(), new WheelOfFortune(), 2, 100) + "\nCorrect: " + -2*418.9819);
            Console.WriteLine("It took " + Minimum.GetTime());

            Console.WriteLine("\nSixHump: " + Minimum.GetMinimum(new SixHump(), new WheelOfFortune(), 2, 100) + "\nCorrect: -1.0316");
            Console.WriteLine("It took " + Minimum.GetTime());

            Console.WriteLine("\nRastrigin: " + Minimum.GetMinimum(new Rastrigin(), new WheelOfFortune(), 2, 100) + "\nCorrect: 0");
            Console.WriteLine("It took " + Minimum.GetTime());
        }
    }
}