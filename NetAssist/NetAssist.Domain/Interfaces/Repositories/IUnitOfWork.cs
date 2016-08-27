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
        void RollbackTransaction();
        void RollbackTransaction(Exception ex);
    }
}
