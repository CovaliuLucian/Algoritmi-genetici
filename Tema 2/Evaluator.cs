using System;
using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2
{
    public static class Evaluator
    {
        public static double Evaluate(this List<string> listOfArgs, IFunction function)
        {

            return function is SixHump
                ? 1 / (function.Calculate(listOfArgs.ToDouble()) + 2) // I think? 1/positive
                : 1 / (function.Calculate(listOfArgs.ToDouble()) + 1);

        }

        public static List<double> Evaluate(this Population population, IFunction function)
        {
            return population.ValueList.Select(listOfArgs => listOfArgs.Evaluate(function)).ToList();
        }
    }
}