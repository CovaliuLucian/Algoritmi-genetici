using System.Collections.Generic;

namespace Tema_3
{
    public interface IMutation
    {
        List<int> Mutate(List<int> chromosome);
    }
}