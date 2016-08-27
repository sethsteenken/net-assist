namespace NetAssist.Domain
{
    public abstract class LookupEntity : Entity<int>
    {
        protected LookupEntity() { }

        protected LookupEntity(string name) : base()
        {
            Name = name?.Trim();
        }

        protected LookupEntity(int id, string name) : base(id)
        {
            Name = name?.Trim();
        }

        public string Name { get; protected set; }
    }
}
