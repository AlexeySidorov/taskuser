using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace Task3.Droid.Infrastructure.Converters
{
    public class UserStatusConvertor : MvxValueConverter<bool, int>
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override int Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? Resource.Drawable.active_user : Resource.Drawable.not_active_user;
        }
    }
}