using System.Collections.Generic;

namespace Tema_3.Selections
{
    public class Selector1 : ISelection
    {
        public List<List<int>> Select(List<List<int>> parents)
        {
            return new List<List<int>>
            {
                parents[0].Fitness() < parents[1].Fitness() ? parents[0] : parents[1],
                parents[2].Fitness() < parents[3].Fitness() ? parents[2] : parents[3]
            };
        }

        public List<List<int>> Select(Population population)
        {
            var tempList = new List<List<int>>();
            for (var i = 0; i < 4; i++)
            {
                var r = Genetics.GetRandom(0, Population.Size);
                tempList.Add(population.ValueList[r]);
            }
            return Select(tempList);
        }
    }
}