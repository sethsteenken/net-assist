using System;

namespace NetAssist.Domain
{
    public interface IDataEntity : IEntity<int>
    {
        Guid Guid { get; }
        bool Archive { get; }
    }
}
