using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using Task3.Domain.Models;
using UIKit;

namespace Task3.iOS.Infrastructure.Converters
{
    public class FigureResourceConvertor : MvxValueConverter<Figure, UIImage>
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
        protected override UIImage Convert(Figure value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Figure.Apple: return UIImage.FromBundle("apple");
                case Figure.Strawberry: return UIImage.FromBundle("strawberry");
                case Figure.Banana: return UIImage.FromBundle("banan");
                default:
                    return null;
            }
        }
    }
}