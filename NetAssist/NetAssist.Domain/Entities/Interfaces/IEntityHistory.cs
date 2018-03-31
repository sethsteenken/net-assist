using System;

namespace NetAssist.Domain
{
    public interface IEntityHistory : IEntity<int>
    {
        Guid EntityGuid { get; }
        int TypeId { get; }
        CommandTypeOption CommandType { get; }
        CommandDate Event { get; }
    }
}
