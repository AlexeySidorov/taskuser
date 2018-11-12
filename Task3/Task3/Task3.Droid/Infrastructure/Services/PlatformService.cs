using System;
using System.IO;
using Android.Content;
using Java.Util;
using Plugin.CurrentActivity;
using Task3.Core.Services;
using static Android.Net.Uri;

namespace Task3.Droid.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        /// <summary>
        /// ��� ���������
        /// </summary>
        public Platform Platform => Platform.Android;

        /// <summary>
        /// Closes the application
        /// </summary>
        public void CloseApplication()
        {
            CrossCurrentActivity.Current.Activity.FinishAffinity();
        }

        /// <summary>
        /// Shows the browser.
        /// </summary>
        /// <param name="url">URL.</param>
        public void ShowBrowser(string url)
        {

        }

        /// <summary>
        /// Gets the local file path.
        /// </summary>
        /// <returns>The local file path.</returns>
        /// <param name="filename">Filename.</param>
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }


        public DateTime ConvertUtcToLocalTimeZone(DateTime dateTimeUtc)
        {
            // get the UTC/GMT Time Zone
            Java.Util.TimeZone utcGmtTimeZone = Java.Util.TimeZone.GetTimeZone("UTC");
            // get the local Time Zone
            Java.Util.TimeZone localTimeZone = Java.Util.TimeZone.Default;
            // convert the DateTime to Java type
            Date javaDate = DateTimeToNativeDate(dateTimeUtc);
            // convert to new time zone
            Date timeZoneDate = ConvertTimeZone(javaDate, utcGmtTimeZone, localTimeZone);
            // convert to systwem.datetime
            DateTime timeZoneDateTime = NativeDateToDateTime(timeZoneDate);

            return timeZoneDateTime.ToLocalTime();
        }

        public string ShowMapsApplication(double latitude, double longitude)
        {
            var geoUri = Parse($"geo:{latitude},{longitude}?q={latitude},{longitude}(My marker)");
            var mapIntent = new Intent(Intent.ActionView, geoUri);

            try
            {
                CrossCurrentActivity.Current.Activity.StartActivity(mapIntent);
            }
            catch (Exception)
            {
                return "Application not found";
            }

            return null;
        }

        public string CallPhone(string phone)
        {
            var uri = Parse($"tel:{phone}");
            var intent = new Intent(Intent.ActionView, uri);

            try
            {
                CrossCurrentActivity.Current.Activity.StartActivity(intent);
            }
            catch (Exception)
            {
                return "Application not found";
            }

            return null;
        }

        public string SendEmail(string email)
        {
            var emailIntent = new Intent(Intent.ActionSend);
            emailIntent.PutExtra(Intent.ExtraEmail, new[] { email });
            emailIntent.PutExtra(Intent.ExtraSubject, "");
            emailIntent.PutExtra(Intent.ExtraText, "");
            emailIntent.SetType("message/rfc822");

            try
            {
                CrossCurrentActivity.Current.Activity.StartActivity(emailIntent);
            }
            catch (Exception)
            {
                return "Application not found";
            }

            return null;
        }

        /// <summary>
        /// Converts a System.DateTime to a Java DateTime
        /// </summary>
        /// <returns>The time to native date.</returns>
        /// <param name="date">Date.</param>
        public static Java.Util.Date DateTimeToNativeDate(DateTime date)
        {
            long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            ).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }

        /// <summary>
        /// Converts a java datetime to system.datetime
        /// </summary>
        /// <returns>The date to date time.</returns>
        /// <param name="date">Date.</param>
        public static DateTime NativeDateToDateTime(Java.Util.Date date)
        {
            long javaDateAsMilliseconds = date.Time;
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(TimeSpan.FromMilliseconds(javaDateAsMilliseconds));
            return dateTime;
        }

        /// <summary>
        /// Converts a date between time zones
        /// </summary>
        /// <returns>The date in the converted timezone.</returns>
        /// <param name="date">Date to convert</param>
        /// <param name="fromTZ">from Time Zone</param>
        /// <param name="toTZ">To Time Zone</param>
        public static Java.Util.Date ConvertTimeZone(Java.Util.Date date, Java.Util.TimeZone fromTZ, Java.Util.TimeZone toTZ)
        {
            long fromTZDst = 0;

            if (fromTZ.InDaylightTime(date))
            {
                fromTZDst = fromTZ.DSTSavings;
            }

            long fromTZOffset = fromTZ.RawOffset + fromTZDst;

            long toTZDst = 0;
            if (toTZ.InDaylightTime(date))
                toTZDst = toTZ.DSTSavings;

            var toTZOffset = toTZ.RawOffset + toTZDst;

            return new Java.Util.Date(date.Time + (toTZOffset - fromTZOffset));
        }

    }
}