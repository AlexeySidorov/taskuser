using System;
using Foundation;

namespace Task3.iOS.Infrastructure.Utils
{
    public static class DateUtility
    {
        /// <summary>
        /// Converts a System.DateTime to an NSDate
        /// </summary>
        /// <returns>The time to native date.</returns>
        /// <param name="date">Date.</param>
        public static NSDate DateTimeToNativeDate(DateTime date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return NSDate.FromTimeIntervalSinceReferenceDate(
                (date - reference).TotalSeconds);
        }

        /// <summary>
        /// Converts a NSDate to System.DateTime
        /// </summary>
        /// <returns>The date to date time.</returns>
        /// <param name="date">Date.</param>
        public static DateTime NativeDateToDateTime(NSDate date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return reference.AddSeconds(date.SecondsSinceReferenceDate);
        }
    }
}
