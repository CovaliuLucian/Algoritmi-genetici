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
            if (function is Schwefel)
                return -function.Calculate(listOfArgs.ToDouble());
            return 1 / (function.Calculate(listOfArgs.ToDouble()) + 2);

        }

        public static List<double> Evaluate(this Population population, IFunction function)
        {
            return population.ValueList.Select(listOfArgs => listOfArgs.Evaluate(function)).ToList();
        }
    }
}