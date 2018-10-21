using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using UIKit;

namespace Task3.iOS.Infrastructure.Converters
{
    public class ActiveUserToImageConvert : MvxValueConverter<bool, UIImage>
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override UIImage Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? UIImage.FromBundle("action_user") : UIImage.FromBundle("not_action_user");
        }
    }
}