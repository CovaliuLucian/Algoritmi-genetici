using System;
using System.Collections.Generic;
using System.IO;

namespace Functions
{
    public class Functie1Prim : IFunction
    {
        public Functie1Prim()
        {
            SearchMaximum = 31;
            SearchMinimum = 0;
        }

        public decimal SearchMinimum { get; set; }
        public decimal SearchMaximum { get; set; }
        public int Counter { get; set; }

        public decimal Calculate(List<decimal> entry)
        {
            if (entry.Count != 1)
                throw new InvalidDataException();
            try
            {
                var number = Convert.ToInt32(entry[0]);
                return (decimal) (Math.Pow(number, 3) - Math.Pow(number, 2) * 60 + 900 * number + 100);
            }
            catch
            {
                throw new InvalidDataException();
            }
        }

        public int Calculate(int entry)  // can not be used trought the interface
        {
            return (int)(Math.Pow(entry, 3) - Math.Pow(entry, 2) * 60 + 900 * entry + 100);
        }
    }
}