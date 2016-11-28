using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace UnderstandingExtensionMethods.Net
{
    internal static class EnumerableExtensions
    {
        internal static string ToDelimitedString<T>(this IEnumerable<T> source)
        {
            return source.ToDelimitedString(x => x.ToString(), CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        }

        internal static string ToDelimitedString<T>(this IEnumerable<T> source, Func<T, string> converter)
        {
            return source.ToDelimitedString(converter, CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        }

        internal static string ToDelimitedString<T>(this IEnumerable<T> source, string separator)
        {
            return source.ToDelimitedString(x => x.ToString(), separator);
        }

        internal static string ToDelimitedString<T>(this IEnumerable<T> source, Func<T, string> converter, string separator)
        {
            return string.Join(separator + " ", source.Select(converter).ToArray());
        }
    }
}
