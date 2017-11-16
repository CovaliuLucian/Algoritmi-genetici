using System;
using System.Diagnostics;
using Functions;

namespace AG_tema_1_prim
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var a = new Stopwatch();
                a.Start();
                Maximum.SetMode(ExploreType.Best);
                Console.WriteLine("Best:");
                Maximum.GetMaximum(new Functie1Prim()).Result.Write();

                Maximum.SetMode(ExploreType.First);
                Console.WriteLine("First:");
                Maximum.GetMaximum(new Functie1Prim()).Result.Write();
                Console.Write("It took: " + a.Elapsed + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("S-o dus drecu'" + e.Message+e.StackTrace);
            }
        }
    }
}