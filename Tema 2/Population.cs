using System.Collections.Generic;

namespace Tema_2
{
    public class Population
    {
        public List<List<string>> ValueList;

        public Population(List<List<string>> valueList)
        {
            ValueList = valueList;
        }

        public Population()
        {
            ValueList = null;
        }
    }
}