using Functions;

namespace Tema_2.Selections
{
    public interface ISelection
    {
        Population Select( Population population, IFunction function);
    }
}