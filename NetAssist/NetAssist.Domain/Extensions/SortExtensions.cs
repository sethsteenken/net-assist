using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NetAssist.Domain
{
    public static class SortExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy, params object[] values)
        {
            return source.OrderBy(new SortCriteria(orderBy), values);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy, SortDirectionOption direction, params object[] values)
        {
            return source.OrderBy(new SortCriteria(orderBy, direction), values);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, SortCriteria sort, params object[] values)
        {
            if (sort == null)
                return source.OrderBy(x => x);

            // Reference - http://stackoverflow.com/a/233505
            string[] props = sort.SortBy.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "p");
            Expression expr = arg;

            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                if (pi == null)
                    throw new InvalidOperationException($"Property not found on OrderBy attempt. IQueryable Item Type: {typeof(T).FullName} | Property Type: {type.FullName} | Property Name: '{prop}' | Full Property Reference: '{sort.SortBy}'.");

                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == sort.QuerySortOperation
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<T>)result;
        }
    }
}
