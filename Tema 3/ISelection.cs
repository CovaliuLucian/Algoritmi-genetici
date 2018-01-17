using System.Collections.Generic;

namespace Tema_3
{
    public interface ISelection
    {
        List<List<int>> Select(List<List<int>> parents);
        List<List<int>> Select(Population population);
    }
}