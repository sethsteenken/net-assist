using System;

namespace NetAssist
{
    public static class EnumExtesnsions
    {
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
}
