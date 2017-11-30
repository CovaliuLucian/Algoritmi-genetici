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

            //var test = Generator.GeneratePopulation(2, -5.12, 5.12, 20);
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

            //var wheel = new Tourney();

            //var wheeled = wheel.Select(test, new DeJong1());
            //wheeled.ValueList.ForEach(x =>
            //{
            //    x.ForEach(b => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            //Console.WriteLine();
            //var crossed = wheeled.CrossOver(new DeJong1(),0.5);
            //crossed.ValueList.ForEach(x =>
            //{
            //    x.ForEach(b => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            //Console.WriteLine();
            //var mutated = wheeled.Mutate(new DeJong1(),0.01);
            //mutated.ValueList.ForEach(x =>
            //{
            //    x.ForEach(b => Console.Write(b.ToDouble() + " "));
            //    Console.WriteLine();
            //});

            //Console.WriteLine("De Jong: " + Minimum.GetMinimum(new DeJong1(), new RankSelection(), 3, 100) +
            //                  "\nCorrect: 0");
            //Console.WriteLine("It took " + Minimum.GetTime());

            //Console.WriteLine("De Jong: " + Minimum.GetMinimum(new DeJong1(), new WheelOfFortune(), 3, 100) +
            //                  "\nCorrect: 0");
            //Console.WriteLine("It took " + Minimum.GetTime());

            Console.WriteLine("De Jong: " + Math.Round(Minimum.GetMinimum(new DeJong1(), new Tourney(), 30, 100),4) +
                              "\nCorrect: 0");
            Console.WriteLine("It took " + Minimum.GetTime());


            const int dimension = 10;
            Console.WriteLine("\nSchwefel: " + Minimum.GetMinimum(new Schwefel(), new Tourney(), dimension, 100) +
                              "\nCorrect: " + -dimension * 418.9819);
            Console.WriteLine("It took " + Minimum.GetTime());


            Console.WriteLine("\nSixHump: " + Minimum.GetMinimum(new SixHump(), new Tourney(), 2, 100) +
                              "\nCorrect: -1.0316");
            Console.WriteLine("It took " + Minimum.GetTime());


            Console.WriteLine("\nRastrigin: " + Minimum.GetMinimum(new Rastrigin(), new Tourney(), 10, 100) +
                              "\nCorrect: 0");
            Console.WriteLine("It took " + Minimum.GetTime());
        }
    }
}