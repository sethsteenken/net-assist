using System;
using System.Collections.Generic;
using System.Linq;

namespace NetAssist
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Traverse<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> childSelector)
        {
            foreach (T item in items)
            {
                yield return item;
                IEnumerable<T> children = childSelector(item);
                foreach (T child in children.Traverse(childSelector))
                {
                    yield return child;
                }
            }
        }

        public static IEnumerable<T> TraverseUsingStack<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> childSelector)
        {
            var stack = new Stack<T>(items);
            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                foreach (var child in childSelector(next))
                    stack.Push(child);
            }
        }
    }
}
