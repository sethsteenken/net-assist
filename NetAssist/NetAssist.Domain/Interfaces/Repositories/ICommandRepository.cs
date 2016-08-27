using System.Collections.Generic;

namespace NetAssist.Domain
{
    public interface ICommandRepository<TType, TKey> where TType : Entity<TKey>
    {
        void AddOrUpdate(TType item);
        void Delete(TType item);
        void AddOrUpdateMany(IEnumerable<TType> items);
        void DeleteMany(IEnumerable<TType> items);
    }
}
