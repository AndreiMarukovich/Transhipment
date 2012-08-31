using System;

namespace Transhipment.Helpers
{
    static class DateTimeHelper
    {
        public static string ToString(DateTimeOffset? dateTime)
        {
            return !dateTime.HasValue ? String.Empty : dateTime.Value.UtcDateTime.ToString("o");
        }

        public static DateTimeOffset? FromString(string dateTime)
        {
            DateTimeOffset result;
            return DateTimeOffset.TryParse(dateTime, out result) ? (DateTimeOffset?)result : null;
        }
    }
}