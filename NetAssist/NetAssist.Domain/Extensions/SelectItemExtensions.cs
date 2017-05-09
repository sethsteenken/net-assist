using System;
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

        public static string LookupName<T>(this IEnumerable<T> items, string value) where T : SelectItem
        {
            if (!items.HasItems())
                return null;

            return items.Where(x => string.Compare(x.Value, value, StringComparison.InvariantCultureIgnoreCase) == 0).Select(x => x.Name).FirstOrDefault();
        }

        public static IEnumerable<T> MarkSelected<T>(this IEnumerable<T> items, int[] selectedIds) where T : SelectItem
        {
            if (!items.HasItems())
                return items;

            foreach (var item in items)
            {
                item.Selected = selectedIds.Contains(item.Id ?? 0);
            }

            return items;
        }
    }
}
