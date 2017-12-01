using System;
using System.Collections.Generic;

namespace Functions
{
    public class Schwefel : IFunction
    {
        public Schwefel()
        {
            SearchMinimum = -500;
            SearchMaximum = 500;
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
                    result -= x * (decimal) Math.Sin(Math.Sqrt(Math.Abs((double) x)))
            );

            return result;
        }

        public double Calculate(List<double> entry)
        {
            Counter++;
            double result = 0;
            entry.ForEach(
                x =>
                    result -= x * Math.Sin(Math.Sqrt(Math.Abs(x)))
            );

            return result;
        }

        public string GetName()
        {
            return "Schwefel";
        }
    }
}