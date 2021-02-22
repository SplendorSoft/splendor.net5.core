using System;
using System.Threading.Tasks;
using System.Transactions;
using splendor.net5.core.contracts;

namespace splendor.net5.core.implementers
{
    public class TSTransaction : ITransaction
    {
        private TransactionScope _scope;
        public async Task Begin(Func<Task> action)
        {
            using(_scope = new()){
                await action();
                await Commit();
            }
        }

        public Task Commit() {
            if(_scope != null) _scope.Complete();
            return Task.CompletedTask;
        }

        public void Dispose(){
            _scope.Dispose();
        }
    }
}