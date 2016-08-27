using System;

namespace NetAssist
{
    public static class ValueTypeExtensions
    {
        public static bool HasValue(this Guid? guid)
        {
            return guid != null && guid != Guid.Empty;
        }
    }
}
