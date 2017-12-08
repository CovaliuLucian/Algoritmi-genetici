using System;
using System.Diagnostics;
using Functions;
using Tema_2;
using Tema_2.Selections;
using Tema_2_Prim.Functions;

namespace Tema_2_Prim
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var rez = Minimum.GetMinimum(new FunctieTema2Prim(), new Tourney(), 2, 100);
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine(Math.Round(rez,4));
        }
    }
}