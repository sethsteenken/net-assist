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
        public static int ParseInteger(this string value)
        {
            return ParseInteger(value, allowEmpty: false);
        }

        public static int ParseInteger(this string value, bool allowEmpty)
        {
            return ParseInteger(value, allowEmpty, throwError: true);
        }

        public static int ParseInteger(this string value, bool allowEmpty, bool throwError)
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
        public static decimal ParseDecimal(this string value)
        {
            return ParseDecimal(value, allowEmpty: false);
        }

        public static decimal ParseDecimal(this string value, bool allowEmpty)
        {
            return ParseDecimal(value, allowEmpty, throwError: true);
        }

        public static decimal ParseDecimal(this string value, bool allowEmpty, bool throwError)
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
        public static double ParseDouble(this string value)
        {
            return ParseDouble(value, allowEmpty: false);
        }

        public static double ParseDouble(this string value, bool allowEmpty)
        {
            return ParseDouble(value, allowEmpty, throwError: true);
        }

        public static double ParseDouble(this string value, bool allowEmpty, bool throwError)
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
        public static bool ParseBool(this string value)
        {
            return ParseBool(value, allowEmpty: false);
        }

        public static bool ParseBool(this string value, bool allowEmpty)
        {
            return ParseBool(value, allowEmpty, throwError: true);
        }

        public static bool ParseBool(this string value, bool allowEmpty, bool throwError)
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
        public static long ParseLong(this string value)
        {
            return ParseLong(value, allowEmpty: false);
        }

        public static long ParseLong(this string value, bool allowEmpty)
        {
            return ParseLong(value, allowEmpty, throwError: true);
        }

        public static long ParseLong(this string value, bool allowEmpty, bool throwError)
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
    }
}
