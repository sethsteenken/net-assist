using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SortDirectionOption direction)
        {
            switch (direction)
            {
                case SortDirectionOption.Ascending:
                    return source.OrderBy(keySelector);
                case SortDirectionOption.Descending:
                    return source.OrderByDescending(keySelector);
                default:
                    throw new InvalidOperationException("OrderBy SortDirection not valid.");
            }
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SortDirectionOption direction)
        {
            switch (direction)
            {
                case SortDirectionOption.Ascending:
                    return source.ThenBy(keySelector);
                case SortDirectionOption.Descending:
                    return source.ThenByDescending(keySelector);
                default:
                    throw new InvalidOperationException("ThenBy SortDirection not valid.");
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortDirectionOption direction)
        {
            switch (direction)
            {
                case SortDirectionOption.Ascending:
                    return source.OrderBy(keySelector);
                case SortDirectionOption.Descending:
                    return source.OrderByDescending(keySelector);
                default:
                    throw new InvalidOperationException("OrderBy SortDirection not valid.");
            }
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortDirectionOption direction)
        {
            switch (direction)
            {
                case SortDirectionOption.Ascending:
                    return source.ThenBy(keySelector);
                case SortDirectionOption.Descending:
                    return source.ThenByDescending(keySelector);
                default:
                    throw new InvalidOperationException("ThenBy SortDirection not valid.");
            }
        }
    }
}
