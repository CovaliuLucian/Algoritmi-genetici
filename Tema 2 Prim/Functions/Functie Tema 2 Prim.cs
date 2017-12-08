using System.Collections.Generic;
using Functions;
using Tema_2;
using Tema_2.Exceptions;
using Tema_2.Selections;

namespace Tema_2_Prim.Functions
{
    public class FunctieTema2Prim : IFunction
    {
        public decimal SearchMinimum { get; set; }
        public decimal SearchMaximum { get; set; }
        public int Counter { get; set; }

        public FunctieTema2Prim()
        {
            SearchMinimum = 0;
            SearchMaximum = 1;
        }

        public decimal Calculate(List<decimal> entry)
        {
            if(entry.Count != 2)
                throw new InvalidArgsException();
            return (decimal)Minimum.GetMinimum(new DeJong1(), new Tourney(), 5, 100, (double)entry[0], (double)entry[1]);
        }

        public double Calculate(List<double> entry)
        {
            if (entry.Count != 2)
                throw new InvalidArgsException();
            return Minimum.GetMinimum(new DeJong1(), new Tourney(), 2, 100, entry[0], entry[1]);
        }

        public double Calculate(List<double> entry, IFunction function, ISelection selector, int dimensions = 5, int size = 100)
        {
            if (entry.Count != 2)
                throw new InvalidArgsException();
            return Minimum.GetMinimum(function, selector, dimensions, size, entry[0], entry[1]);
        }

        public string GetName()
        {
            return "Algoritm genetic de la Tema 2";
        }
    }
}