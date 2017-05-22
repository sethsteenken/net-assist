namespace NetAssist.Domain
{
    public interface IRepository<TType, TKey> : ICommandRepository<TType, TKey>, IQueryRepository<TType, TKey> where TType : IEntity<TKey>
    {

    }
}
