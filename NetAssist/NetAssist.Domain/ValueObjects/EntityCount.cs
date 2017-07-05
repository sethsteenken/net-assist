namespace NetAssist.Domain
{
    public class EntityCount : ValueObject<EntityCount>
    {
        protected EntityCount() { }

        public EntityCount(int id, int count)
        {
            Id = id;
            Count = count;
        }

        public int Id { get; private set; }
        public int Count { get; private set; }
    }
}
