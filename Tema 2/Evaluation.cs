using System.Collections.Generic;
using Functions;

namespace Tema_2
{
    public class Evaluation
    {
        public static double Fitness(IFunction function, List<decimal> listOfArgs)
        {
            var result = function.Calculate(listOfArgs);
            if (result == 0)
                return int.MaxValue;
            return (double)(1 / result);
        }

        public static double Fitness(IFunction function, List<double> listOfArgs)
        {
            var convertedList = new List<decimal>();
            listOfArgs.ForEach((x) => convertedList.Add((decimal) x));
            return Fitness(function, convertedList);
        }
    }
}