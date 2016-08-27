using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NetAssist
{
    public static class StringExtensions
    {
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
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
