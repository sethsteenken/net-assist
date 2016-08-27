using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NetAssist
{
    public static class StringExtensions
    {
        internal const string DefaultDelimiter = ",";

        public static string[] ToWords(this string text)
        {
            return ToWords(text, lower: false);
        }

        public static string[] ToWords(this string text, bool lower)
        {
            text = text.SetEmptyToNull();
            if (string.IsNullOrWhiteSpace(text))
                return new string[] { };
            var words = (lower ? text.ToLower() : text).Split(' ');
            return words;
        }

        public static string SetEmptyToNull(this string value)
        {
            return SetEmptyToNull(value, trim: true);
        }

        public static string SetEmptyToNull(this string value, bool trim)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return trim ? value.Trim() : value;
        }

        public static string SetNullToEmpty(this string value)
        {
            return SetNullToEmpty(value, trim: true);
        }

        public static string SetNullToEmpty(this string value, bool trim)
        {
            if (value == null)
                return string.Empty;
            else
                return trim ? value.Trim() : value;
        }

        public static string RemoveSpecialCharacters(this string input, string customRegEx = null)
        {
            Regex r = new Regex(customRegEx == null ? RegularExpressions.SpecialCharacters : customRegEx, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, string.Empty);
        }

        public static void RemoveArea(this StringBuilder sb, string start, string end)
        {
            int startplaceholderindex = sb.ToString().IndexOf(start);
            int endplaceholderindex = sb.ToString().IndexOf(end);
            sb.Remove(startplaceholderindex, endplaceholderindex - startplaceholderindex + end.Length);
        }

        public static string Truncate(this string value, int maxLength)
        {
            return Truncate(value, maxLength, appendTrail: false);
        }

        public static string Truncate(this string value, int maxLength, bool appendTrail)
        {
            return Truncate(value, maxLength, appendTrail, trail: "...");
        }

        public static string Truncate(this string baseString, int maxLength, bool appendTrail, string trail)
        {
            if (string.IsNullOrWhiteSpace(baseString) || baseString.Length <= maxLength)
                return baseString;

            return string.Concat(baseString.Substring(0, Math.Min(baseString.Length, maxLength)), appendTrail ? trail.SetNullToEmpty() : string.Empty);
        }

        public static string ToPlural(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            if (value.EndsWith("y"))
                return string.Concat(value.Remove(value.Length - 1), "ies");
            else
                return string.Concat(value, "s");
        }

        public static string ToUrlFriendlyString(this string value)
        {
            value = value.SetNullToEmpty(trim: false);
            if (string.IsNullOrEmpty(value))
                return value;

            string friendlyValue = value.RemoveAccent().ToLower(); //clean and lower
            friendlyValue = friendlyValue.Replace("-", " "); // replace existing hypens with a space
            friendlyValue = Regex.Replace(friendlyValue, @"[^a-z0-9\s-_]", ""); // invalid chars  
            friendlyValue = Regex.Replace(friendlyValue, @"\s+", " ").Trim(); // convert multiple spaces into one space 
            friendlyValue = Regex.Replace(friendlyValue, @"\s", "-"); // hyphens   

            return friendlyValue;
        }

        private static string RemoveAccent(this string txt)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }


        public static List<int> ToIntList(this string value)
        {
            return ToIntList(value, DefaultDelimiter);
        }

        public static List<int> ToIntList(this string value, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<int>();

            if (string.IsNullOrWhiteSpace(delimiter) || delimiter.Length > 1)
                delimiter = DefaultDelimiter;

            value = Regex.Replace(value, @"[^0-9a-zA-Z]+", delimiter);
            var items = value.Split(delimiter[0]);
            var list = new List<int>();

            foreach (var item in items)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    int itemAsInt = 0;
                    if (int.TryParse(item, out itemAsInt))
                        list.Add(itemAsInt);
                }
            }

            return list;
        }

        public static string ToSentenceFriendlyText(this IEnumerable<string> list)
        {
            return ToSentenceFriendlyText(list, "and");
        }

        public static string ToSentenceFriendlyText(this IEnumerable<string> list, string lastItemTextSeparator)
        {
            if (!list.HasItems())
                return string.Empty;

            var items = new List<string>(list.Where(x => !string.IsNullOrWhiteSpace(x)));

            if (items.Count == 1)
                return items[0].SetNullToEmpty();

            if (items.Count == 2)
                return $"{items[0]} {lastItemTextSeparator} {items[1]}";

            var sb = new StringBuilder();

            for (int i = 1; i <= items.Count; i++)
            {
                sb.Append(items[i - 1]);
                if (i != items.Count)
                {
                    sb.Append(", "); // always have Oxford comma
                    if (i == (items.Count - 1))
                        sb.Append($"{lastItemTextSeparator} ");
                }
            }

            return sb.ToString();
        }
    }
}
