using System;

namespace Fluentley.SendGrid.Common.Extensions
{
    internal static class TimeExtensions
    {
        public static DateTime? EpocTimeToDateTime(this long? epocTimeFormat)
        {
            if (!epocTimeFormat.HasValue)
                return null;

            var epocDateTimeStartingPoint = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epocDateTimeStartingPoint.AddSeconds(epocTimeFormat.Value);
        }

        public static DateTime EpocTimeToDateTime(this long epocTimeFormat)
        {
            var epocDateTimeStartingPoint = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epocDateTimeStartingPoint.AddSeconds(epocTimeFormat);
        }

        public static long ToUnixTime(this DateTime datetime)
        {
            var dto = new DateTimeOffset(datetime, TimeSpan.Zero);
            return dto.ToUnixTimeSeconds();
        }
    }
}