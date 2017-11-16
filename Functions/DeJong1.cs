using System.Collections.Generic;
using System.Linq;

namespace Functions
{
    public class DeJong1 : IFunction
    {
        public DeJong1()
        {
            SearchMinimum = (decimal) -5.12;
            SearchMaximum = (decimal) 5.12;
        }

        public decimal SearchMinimum { get; set; }
        public decimal SearchMaximum { get; set; }
        public int Counter { get; set; }

        public decimal Calculate(List<decimal> entry)
        {
            Counter++;
            return entry.Select(t => t * t).Sum();
        }
    }
}