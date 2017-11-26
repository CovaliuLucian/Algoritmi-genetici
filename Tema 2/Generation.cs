using System.Collections.Generic;

namespace Tema_2
{
    public class Generation
    {
        public List<List<string>> ValueList;

        public Generation(List<List<string>> valueList)
        {
            ValueList = valueList;
        }

        public Generation()
        {
            ValueList = null;
        }
    }
}