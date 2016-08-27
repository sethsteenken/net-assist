using System.Collections;

namespace NetAssist
{
    public static class EnumerableHelper
    {
        public static bool IsEnumerable(object item)
        {
            return item.GetType().IsGenericType && item is IEnumerable;
        } 
    }
}
