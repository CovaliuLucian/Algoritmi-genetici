using Functions;

namespace Tema_2_Prim.Selectors
{
    public interface ISelection
    {
        Population Select(Population population, IFunction function);
    }
}