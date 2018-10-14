using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace Task3.iOS.Infrastructure.Converters
{
    public class HiddenConvert : MvxValueConverter<bool, int>
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override int Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? 0 : -1;
        }
    }
}