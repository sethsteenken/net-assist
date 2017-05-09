using System;
using System.Text;

namespace NetAssist.Domain
{
    public class SelectItem : ValueObject<SelectItem>
    {
        protected SelectItem() { }

        public SelectItem(string value) : this(value, value) { }

        public SelectItem(string value, string name) : this(value, name, false)
        {

        }

        public SelectItem(int id, string name) : this(id.ToString(), name)
        { }

        public SelectItem(string value, string name, bool selected)
        {
            Value = value;
            Name = name;
            Selected = selected;
        }

        public SelectItem(int id, string name, bool selected) : this(id.ToString(), name, selected)
        { }

        public SelectItem(Enum enumValue) : this(enumValue.ToInt(), enumValue.ToFriendlyName())
        {

        }

        public virtual string Value { get; protected set; }
        public virtual string Name { get; protected set; }
        public bool Selected { get; set; } = false;

        public virtual int? Id
        {
            get { return string.IsNullOrWhiteSpace(Value) ? (int?)null : Value.ParseToInteger(allowEmpty: true, throwError: false); }
        }

        public void IndentName(int level)
        {
            IndentName(level, "..");
        }

        public void IndentName(int level, string indentation)
        {
            var fullIndentation = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                fullIndentation.Append(indentation);
            }
            Name = string.Concat(fullIndentation.ToString(), Name);
        }

        public SelectItem Copy()
        {
            return new SelectItem(this.Value, this.Name);
        }

        public static SelectItem Default => new SelectItem();
    }
}
