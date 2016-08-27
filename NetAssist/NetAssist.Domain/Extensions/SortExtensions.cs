using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NetAssist.Domain
{
    public static class SortExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy, params object[] values)
        {
            return source.OrderBy(new SortCriteria(orderBy), values);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy, SortDirectionOption direction, params object[] values)
        {
            return source.OrderBy(new SortCriteria(orderBy, direction), values);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, SortCriteria sort, params object[] values)
        {
            //Reference - http://stackoverflow.com/a/233505
            string[] props = sort.SortBy.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "p");
            Expression expr = arg;

            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
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
