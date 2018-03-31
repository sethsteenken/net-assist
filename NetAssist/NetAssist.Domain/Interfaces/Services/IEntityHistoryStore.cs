namespace NetAssist.Domain
{
    public interface IEntityHistoryStore
    {
        void ProcessCommand(IEntityGuid entity, CommandTypeOption type);
    }
}
