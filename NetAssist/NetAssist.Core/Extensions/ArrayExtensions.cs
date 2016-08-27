using System.Linq;

namespace NetAssist
{
    public static class ArrayExtensions
    {
        public static bool In<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }
    }
}
