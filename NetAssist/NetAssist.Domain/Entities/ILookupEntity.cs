namespace NetAssist.Domain
{
    public interface ILookupEntity : IEntity<int>
    {
        string Name { get; }
    }
}
