namespace NetAssist.Domain
{
    public interface IEntityHistoryUpdated
    {
        void OnHistoryUpdate(IEntityHistory entityHistory);
    }
}
