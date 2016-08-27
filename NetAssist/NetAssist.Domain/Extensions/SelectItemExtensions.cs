using System.Collections.Generic;
using System.Linq;

namespace NetAssist.Domain
{
    public static class SelectItemExtensions
    {
        public static IList<int> ToIdList<T>(this IEnumerable<T> items) where T : SelectItem
        {
            if (!items.HasItems())
                return new List<int>();

            return items.Where(x => x.Id.CleanNullable() != null).Select(x => (int)x.Id).ToList();
        }
    }
}
