using System;
using System.Threading.Tasks;

namespace NetAssist.Domain
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        bool TransactionOpen { get; }
        void BeginTransaction();
        void CommitTransaction();
        Task CommitTransactionAsync();
        void RollbackTransaction();
        void RollbackTransaction(Exception ex);
    }
}
