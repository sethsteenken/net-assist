using System;

namespace NetAssist.Domain
{
    public interface IEntity<TId>
    {
        TId Id { get; }
        bool IsNew { get; }
    }
}
