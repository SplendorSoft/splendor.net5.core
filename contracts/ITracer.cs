using System.Threading.Tasks;
using splendor.net5.core.commons;

namespace splendor.net5.core.contracts
{
    public interface ITracer
    {
        Task TraceAdd<E>(E entity, DTrace trace) where E: class, new();
        Task TraceEdit<E>(E entity, DTrace trace) where E: class, new();
    }
}