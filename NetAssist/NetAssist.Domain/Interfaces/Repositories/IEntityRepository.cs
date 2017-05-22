using System;
using System.Collections.Generic;

namespace NetAssist.Domain
{
    public interface IEntityRepository<T> : IRepository<T, int> where T : IDataEntity
    {
        T GetByGuid(Guid guid);
        int GetId(Guid guid);
        IReadOnlyList<T> GetAll(IList<Guid> ids);
        Guid GetGuid(int id);
    }
}
