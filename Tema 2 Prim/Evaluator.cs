using System.Collections.Generic;
using System.Linq;
using Functions;

namespace Tema_2_Prim
{
    public static class Evaluator
    {
        //private static IAppCache _cache = new CachingService();

        public static double Evaluate(this List<string> listOfArgs, IFunction function)
        {
            //Func<double> toGet = () =>
            //{
            //    if (function is Schwefel)
            //        return -function.Calculate(listOfArgs.ToDouble()) * 10;
            //    if (function is SixHump)
            //        return 1 / (function.Calculate(listOfArgs.ToDouble()) + 1.032);
            //    return 1 / function.Calculate(listOfArgs.ToDouble()) + double.Epsilon;
            //};

            //return _cache.GetOrAdd(listOfArgs.GetHashCode().ToString(), toGet);


            if (function is Schwefel)
                return -function.Calculate(listOfArgs.ToDouble()) * 10;
            if (function is SixHump)
                return 1 / (function.Calculate(listOfArgs.ToDouble()) + 1.032);
            return 1 / function.Calculate(listOfArgs.ToDouble()) + double.Epsilon;
        }

        public static List<double> Evaluate(this Population population, IFunction function)
        {
            return population.ValueList.Select(listOfArgs => listOfArgs.Evaluate(function)).ToList();
        }
    }
}