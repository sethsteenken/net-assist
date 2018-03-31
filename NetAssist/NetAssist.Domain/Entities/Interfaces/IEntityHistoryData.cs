namespace NetAssist.Domain
{
    public interface IEntityHistoryData : IEntity<int>
    {
        string Value { get; }
    }
}
