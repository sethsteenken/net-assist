using System.Collections.Generic;

namespace NetAssist.Domain
{
    public interface IQueryRepository<TType, TKey> where TType : IEntity<TKey>
    {
        TType GetById(TKey id);
        IReadOnlyList<TType> GetAll();
        IReadOnlyList<TType> GetAll(IList<TKey> ids);
        int Count();
    }
}
