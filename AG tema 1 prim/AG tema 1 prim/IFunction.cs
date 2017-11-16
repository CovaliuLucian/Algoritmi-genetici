using System.Collections.Generic;

namespace AG_Lab_0
{
    internal interface IFunction
    {
        decimal SearchMinimum { get; set; }

        decimal SearchMaximum { get; set; }

        int Counter { get; set; }
        decimal Calculate(List<decimal> entry);
    }
}