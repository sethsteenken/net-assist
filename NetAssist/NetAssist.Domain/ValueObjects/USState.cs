namespace NetAssist.Domain
{
    public class USState : ValueObject<USState>
    {
        protected USState() { }
        public USState(string name, string abbr)
        {
            Name = name;
            Abbreviation = abbr;
        }

        public string Name { get; private set; }
        public string Abbreviation { get; private set; }

        public override string ToString()
        {
            return $"{Name} ({Abbreviation})";
        }
    }
}
