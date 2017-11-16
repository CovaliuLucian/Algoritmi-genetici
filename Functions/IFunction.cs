using System.Collections.Generic;

namespace Functions
{
    public interface IFunction
    {
        decimal SearchMinimum { get; set; }

        decimal SearchMaximum { get; set; }

        int Counter { get; set; }
        decimal Calculate(List<decimal> entry);
    }
}