using System;
using System.Collections.Generic;

namespace AG_Lab_0
{
    public class Rastrigin : IFunction
    {
        public Rastrigin()
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
            decimal result = 0;
            entry.ForEach(
                x =>
                    result += x * x - (decimal) (10 * Math.Cos(2 * Math.PI * (double) x))
            );
            result += 10 * entry.Count;
            return result;
        }
    }
}