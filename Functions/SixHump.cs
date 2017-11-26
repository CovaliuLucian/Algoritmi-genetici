using System;
using System.Collections.Generic;
using System.IO;

namespace Functions
{
    public class SixHump : IFunction
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

        public double Calculate(List<double> entry)
        {
            Counter++;
            if (entry.Count != 2)
                throw new InvalidDataException();
            return ((4 - 2.1 * Math.Pow(entry[0], 2) +
                              Math.Pow(entry[0], 4) / 3) * Math.Pow(entry[0], 2) +
                             entry[0] * entry[1] + (-4 + 4 * Math.Pow(entry[1], 2)) *
                             Math.Pow(entry[1], 2));
        }
    }
}