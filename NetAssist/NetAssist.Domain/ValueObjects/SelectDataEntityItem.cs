using System;

namespace NetAssist.Domain
{
    public abstract class SelectDataEntityItem : SelectItem
    {
        protected SelectDataEntityItem() : base() { }

        public SelectDataEntityItem(string value, string name, Guid guid) : base (value, name)
        {
            Guid = guid;
        }

        public SelectDataEntityItem(int id, string name, Guid guid) : base(id, name)
        {
            Guid = guid;
        }

        public Guid Guid { get; private set; }
    }
}
