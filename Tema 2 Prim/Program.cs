using System;
using System.Diagnostics;
using Functions;
using Tema_2_Prim;
using Tema_2_Prim.Selectors;

namespace Tema_2_Prim
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var rez = Minimum.GetMinimum(new DeJong1(), new Tourney(), 10, 100);
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine(Math.Round(rez,10));
        }
    }
}