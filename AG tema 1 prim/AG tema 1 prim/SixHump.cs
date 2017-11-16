using System;
using System.Collections.Generic;
using System.IO;

namespace AG_Lab_0
{
    internal class SixHump : IFunction
    {
        public SixHump()
        {
            SearchMinimum = -2;
            SearchMaximum = 2;
        }

        public decimal SearchMinimum { get; set; }
        public decimal SearchMaximum { get; set; }
        public int Counter { get; set; }

        public decimal Calculate(List<decimal> entry)
        {
            Counter++;
            if (entry.Count != 2)
                throw new InvalidDataException();
            return (decimal) ((4 - 2.1 * Math.Pow((double) entry[0], 2) +
                               Math.Pow((double) entry[0], 4) / 3) * Math.Pow((double) entry[0], 2) +
                              (double) (entry[0] * entry[1]) + (-4 + 4 * Math.Pow((double) entry[1], 2)) *
                              Math.Pow((double) entry[1], 2));
        }
    }
}