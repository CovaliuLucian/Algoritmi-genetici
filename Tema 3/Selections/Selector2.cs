using System;
using System.Collections.Generic;
using System.Linq;

namespace Tema_3.Selections
{
    public class Selector2 : ISelection
    {
        public List<List<int>> Select(List<List<int>> parents)
        {
            throw new NotImplementedException();
        }

        public List<List<int>> Select(Population population)
        {
            var ordered = population.ValueList.OrderBy(list => list.Fitness());
            return new List<List<int>>
            {
                ordered.First(),
                ordered.First()
            };
        }
    }
}