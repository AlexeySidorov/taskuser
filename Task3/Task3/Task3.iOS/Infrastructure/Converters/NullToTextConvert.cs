using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace Task3.iOS.Infrastructure.Converters
{
    public class NullToTextConvert : MvxValueConverter<string, string>
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value) ? value : "Not required";
        }
    }
}