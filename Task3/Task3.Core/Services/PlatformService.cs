using System;
using System.Threading.Tasks;

namespace Task3.Core.Services
{
    public interface IPlatformService
    {
        /// <summary>
        /// Тип платформы
        /// </summary>
        Platform Platform { get; }

        /// <summary>
        /// Запустить браузер
        /// </summary>
        void ShowBrowser(string url);

        /// <summary>
        /// Локальный путь на устроистве
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        string GetLocalFilePath(string filename);

        /// <summary>
        /// Converts the UTCT o local time zone.
        /// </summary>
        /// <returns>The UTCT o local time zone.</returns>
        /// <param name="dateTimeUtc">Date time UTC.</param>
        DateTime ConvertUtcToLocalTimeZone(DateTime dateTimeUtc);

        string ShowMapsApplication(double latitude, double longitude);

        string CallPhone(string phone);

        string SendEmail(string email);
    }

    public enum Platform
    {
        Android,
        Ios,
        WinPhone,
        WinStore,
        MacOs
    }
}
