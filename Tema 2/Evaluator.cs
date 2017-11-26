using System;
using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2
{
    public static class Evaluator
    {
        public static double Evaluate(this List<string> listOfArgs,IFunction function)
        {
            try
            {
                return 1 / function.Calculate(listOfArgs.ToDouble());
            }
            catch (DivideByZeroException)
            {
                return double.PositiveInfinity;
            }
        }


        public static List<double> Evaluate(this Generation generation, IFunction function)
        {
            return generation.ValueList.Select(listOfArgs => listOfArgs.Evaluate(function)).ToList();
        }
    }
}