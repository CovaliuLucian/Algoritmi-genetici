using System.Collections.Generic;
using Functions;

namespace Tema_2.Selections
{
    public class RankSelection : ISelection
    {
        public Population Select(Population population, IFunction function)
        {
            var evaluated = population.Evaluate(function);
            var dictionary = new Dictionary<int, List<string>>();
            for (var i = 0; i < evaluated.Count; i++)
                dictionary.Add(i, population.ValueList[i]);
            //foreach (var pair in dictionary)
            //{
            //    if(GetB)
            //}

            return null;
        }
    }
}