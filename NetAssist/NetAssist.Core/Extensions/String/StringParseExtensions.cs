using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAssist
{
    public static class StringParseExtensions
    {
        #region Parse Integer
        public static int ParseToInteger(this string value)
        {
            return ParseToInteger(value, allowEmpty: false);
        }

        public static int ParseToInteger(this string value, bool allowEmpty)
        {
            return ParseToInteger(value, allowEmpty, throwError: true);
        }

        public static int ParseToInteger(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return 0;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return 0;
            }

            int num = 0;
            if (!int.TryParse(value, out num))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as integer.");
                else
                    num = 0;
            }

            return num;
        }
        #endregion

        #region Parse Decimal
        public static decimal ParseToDecimal(this string value)
        {
            return ParseToDecimal(value, allowEmpty: false);
        }

        public static decimal ParseToDecimal(this string value, bool allowEmpty)
        {
            return ParseToDecimal(value, allowEmpty, throwError: true);
        }

        public static decimal ParseToDecimal(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return 0.0M;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return 0.0M;
            }

            decimal num = 0.0M;
            if (!decimal.TryParse(value, out num))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as decimal.");
                else
                    num = 0.0M;
            }

            return num;
        }
        #endregion

        #region Parse Double
        public static double ParseToDouble(this string value)
        {
            return ParseToDouble(value, allowEmpty: false);
        }

        public static double ParseToDouble(this string value, bool allowEmpty)
        {
            return ParseToDouble(value, allowEmpty, throwError: true);
        }

        public static double ParseToDouble(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return 0;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return 0;
            }

            double num = 0;
            if (!double.TryParse(value, out num))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as double.");
                else
                    num = 0;
            }

            return num;
        }
        #endregion

        #region Parse Bool
        public static bool ParseToBool(this string value)
        {
            return ParseToBool(value, allowEmpty: false);
        }

        public static bool ParseToBool(this string value, bool allowEmpty)
        {
            return ParseToBool(value, allowEmpty, throwError: true);
        }

        public static bool ParseToBool(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return false;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return false;
            }

            bool booleanValue = false;
            if (!bool.TryParse(value, out booleanValue))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as bool.");
                else
                    booleanValue = false;
            }

            return booleanValue;
        }
        #endregion

        #region Parse Long
        public static long ParseToLong(this string value)
        {
            return ParseToLong(value, allowEmpty: false);
        }

        public static long ParseToLong(this string value, bool allowEmpty)
        {
            return ParseToLong(value, allowEmpty, throwError: true);
        }

        public static long ParseToLong(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return 0;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return 0;
            }

            long num = 0;
            if (!long.TryParse(value, out num))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as long.");
                else
                    num = 0;
            }

            return num;
        }
        #endregion

        #region Parse Float
        public static float ParseToFloat(this string value)
        {
            return ParseToFloat(value, allowEmpty: false);
        }

        public static float ParseToFloat(this string value, bool allowEmpty)
        {
            return ParseToFloat(value, allowEmpty, throwError: true);
        }

        public static float ParseToFloat(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return 0;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return 0;
            }

            float num = 0;
            if (!float.TryParse(value, out num))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as float.");
                else
                    num = 0;
            }

            return num;
        }
        #endregion

        #region Parse DateTime
        public static DateTime? ParseToDateTime(this string value)
        {
            return ParseToDateTime(value, allowEmpty: false);
        }

        public static DateTime? ParseToDateTime(this string value, bool allowEmpty)
        {
            return ParseToDateTime(value, allowEmpty, throwError: true);
        }

        public static DateTime? ParseToDateTime(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return null;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return null;
            }

            DateTime date;
            if (!DateTime.TryParse(value, out date))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as DateTime.");
                else
                    return null;
            }

            return date;
        }
        #endregion

        #region Parse Guid
        public static Guid? ParseToGuid(this string value)
        {
            return ParseToGuid(value, allowEmpty: false);
        }

        public static Guid? ParseToGuid(this string value, bool allowEmpty)
        {
            return ParseToGuid(value, allowEmpty, throwError: true);
        }

        public static Guid? ParseToGuid(this string value, bool allowEmpty, bool throwError)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (allowEmpty)
                    return null;
                else if (throwError)
                    throw new ArgumentNullException(nameof(value));
                else
                    return null;
            }

            Guid guid;
            if (!Guid.TryParse(value, out guid))
            {
                if (throwError)
                    throw new FormatException($"String value of {value} not correct format for parsing as Guid.");
                else
                    return null;
            }

            return guid;
        }
        #endregion
    }
}
