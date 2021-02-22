using System;
using System.Threading.Tasks;

namespace splendor.net5.core.contracts
{
    public interface ITransaction: IDisposable
    {
        Task Begin(Func<Task> action);
        Task Commit();
    }
}