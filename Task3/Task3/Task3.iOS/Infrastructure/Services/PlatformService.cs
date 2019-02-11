using System;
using System.IO;
using Foundation;
using Task3.Core.Services;
using Task3.iOS.Infrastructure.Utils;
using UIKit;

namespace Task3.iOS.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        /// <summary>
        /// Тип платформы
        /// </summary>
        public Platform Platform => Platform.Ios;

        /// <summary>
        /// Локальный путь на устроистве
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

        /// <summary>
        /// Запустить браузер
        /// </summary>
        public void ShowBrowser(string url)
        {
            var urlBrowser = new NSUrl(url);
            if (UIApplication.SharedApplication.CanOpenUrl(urlBrowser))
                UIApplication.SharedApplication.OpenUrl(urlBrowser);
        }

        /// <summary>
        /// Converts the UTCT o local time zone.
        /// </summary>
        /// <returns>The UTCT o local time zone.</returns>
        /// <param name="dateTimeUtc">Date time UTC.</param>
        public DateTime ConvertUtcToLocalTimeZone(DateTime dateTimeUtc)
        {
            var sourceTimeZone = new NSTimeZone("UTC");
            var destinationTimeZone = NSTimeZone.LocalTimeZone;
            var sourceDate = DateUtility.DateTimeToNativeDate(dateTimeUtc);
            var sourceGmtOffset = (int)sourceTimeZone.SecondsFromGMT(sourceDate);
            var destinationGmtOffset = (int)destinationTimeZone.SecondsFromGMT(sourceDate);
            var interval = destinationGmtOffset - sourceGmtOffset;
            var destinationDate = sourceDate.AddSeconds(interval);
            var dateTime = DateUtility.NativeDateToDateTime(destinationDate);

            return dateTime;
        }

        public string ShowMapsApplication(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public string CallPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public string SendEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}