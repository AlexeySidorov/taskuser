using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using Task3.Domain.Models;
using UIKit;

namespace Task3.iOS.Infrastructure.Converters
{
    public class StatusColorConvertor : MvxValueConverter<ColorType, UIColor>
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
        protected override UIColor Convert(ColorType value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ColorType.Blue: return UIColor.Blue;
                case ColorType.Green: return UIColor.Green;
                case ColorType.Brown: return UIColor.Brown;
                default:
                    return null;
            }
        }
    }
}