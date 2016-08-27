using System.Linq;

namespace NetAssist.Domain
{
    public static class QueryExtensions
    {
        public static IQueryable<T> PagedAndSorted<T>(this IQueryable<T> query, PageCriteria paging, SortCriteria sort)
        {
            //simply sort and page
            return query.OrderBy(sort).Paged(paging);
        }

        public static IQueryable<T> PagedAndSorted<T>(this IQueryable<T> query, PageCriteria paging, SortCriteria sort, out int total)
        {
            return query.OrderBy(sort).Paged(paging, out total);
        }

        public static IQueryable<T> Paged<T>(this IQueryable<T> query, PageCriteria paging)
        {
            return query.Skip(paging.StartIndex).Take(paging.Size);
        }

        public static IQueryable<T> Paged<T>(this IQueryable<T> query, PageCriteria paging, out int total)
        {
            total = query.Count(); //grab count of total before paging

            return query.Paged(paging);
        }
    }
}
