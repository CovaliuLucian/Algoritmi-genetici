using System;
using System.IO;
using Functions;

namespace AG_Lab_0
{
    internal class Tracer
    {
        private static bool _simple = true;

        public static void Counter(IFunction function, decimal value)
        {
            if (!_simple)
                Console.WriteLine(value + " at " + function.Counter + " calls");
        }

        public static void Trace(bool simple = true, int start = 1000, int finish = 128000, int multi = 2)
        {
            _simple = simple;

            Minimum.SetParameters(30, 1000, (decimal) 0.1);
            Console.WriteLine("DeJong: " + Minimum.GetMinimum(new DeJong1(), 30).Result + "     Corect: 0");
            Minimum.CountTime();

            Minimum.SetParameters(30, 1000, (decimal) 0.1);
            const int schwefelConst = 30;
            Console.WriteLine(
                "Schwefel: " + Minimum.GetMinimum(new Schwefel(), schwefelConst).Result + "     Corect: {0}",
                -schwefelConst * 418.9829);
            Minimum.CountTime();

            Minimum.SetParameters(100000, 1000, (decimal) 0.001);
            Minimum.SetParameters();
            try
            {
                Console.WriteLine(
                    "SixHump: " + Minimum.GetMinimum(new SixHump(), 2).Result + "     Corect: -1.0316");
            }
            catch (InvalidDataException exp)
            {
                Console.WriteLine(exp.Message);
            }

            Minimum.CountTime();

            Minimum.SetParameters(30, 1000, (decimal) 0.01);
            Console.WriteLine("Rastrigin: " + Minimum.GetMinimum(new Rastrigin(), 30).Result + "     Corect: 0");
            Minimum.CountTime();
        }
    }
}