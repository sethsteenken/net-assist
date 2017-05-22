using System.Collections.Generic;
using System.Linq;

namespace NetAssist.Domain
{
    public static class DataEntityExtensions
    {
        public static IQueryable<T> Active<T>(this IQueryable<T> query) where T : DataEntity
        {
            return query.Where(x => !x.Archive);
        }

        public static IEnumerable<T> Active<T>(this ICollection<T> query) where T : DataEntity
        {
            return query.Where(x => !x.Archive);
        }

        public static IEnumerable<T> Active<T>(this IEnumerable<T> query) where T : DataEntity
        {
            return query.Where(x => !x.Archive);
        }
    }
}
