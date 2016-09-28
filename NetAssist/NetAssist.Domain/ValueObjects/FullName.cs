using System.Text;

namespace NetAssist.Domain
{
    public class FullName : Name
    {
        public FullName(string firstName, string lastName) : this (firstName, null, lastName)
        {

        }

        public FullName(string firstName, string middleName, string lastName) : base (firstName, lastName)
        {
            MiddleName = middleName.SetEmptyToNull();
        }

        protected FullName() : base() {}

        public string MiddleName { get; private set; }

        public override string Initials => string.Concat(FirstName?[0], MiddleName?[0], LastName?[0]);

        public override string ToFormalString()
        {
            if (string.IsNullOrWhiteSpace(LastName))
                return ToString();

            var sb = new StringBuilder();
            sb.Append(LastName);
            sb.Append(", ");

            if (!string.IsNullOrWhiteSpace(FirstName))
                sb.Append(string.Concat(FirstName, " "));

            if (string.IsNullOrWhiteSpace(MiddleName))
                sb.Append(string.Concat(MiddleName, " "));

            return sb.ToString().TrimEnd(' ');
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(FirstName))
                sb.Append(string.Concat(FirstName, " "));

            if (!string.IsNullOrWhiteSpace(MiddleName))
                sb.Append(string.Concat(MiddleName, " "));

            if (!string.IsNullOrWhiteSpace(LastName))
                sb.Append(string.Concat(LastName, " "));

            return sb.ToString().TrimEnd(' ');
        }
    }
}
