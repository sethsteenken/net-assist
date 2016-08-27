using NetAssist.Validation;
using System.Collections.Generic;

namespace NetAssist.Domain
{
    public abstract class CacheComponent
    {
        protected CacheComponent(string name)
        {
            Guard.Begin().IsNotNull(name, nameof(name)).Check();
            Name = name.Trim();
        }

        public string Name { get; private set; }

        public IReadOnlyList<string> DataCacheKeys { get; protected set; }
        public IReadOnlyList<CacheAction> CacheActions { get; protected set; }
        public IReadOnlyList<string> CachePaths { get; protected set; }
    }
}
