using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Website.Models.ExtensionMethods
{
    public static class FormatExtensions
    {
        public static string ToDisplay(this DateTime dateTime)
        {
            return dateTime.ToString("dd, MMM yyyy");
        }

        public static string DisplayAsDate(this string dateTime)
        {
            DateTime date = DateTime.Now;
            if (DateTime.TryParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None, out date))
            {
                return date.ToDisplay();
            }
            return dateTime;
        }

        public static string FirstSentence(this string htmltext)
        {
            if (string.IsNullOrEmpty(htmltext)) return "";

            string raw = StripHtml(htmltext);
            var index = raw.IndexOfAny(new char[] {'.', '?', '!'});
            raw = raw.Substring(0, index);
            if (raw.EndsWith(".")) return raw.Substring(0, raw.Length - 1);
            return raw;
        }

        public static string StripHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
        }
    }
}