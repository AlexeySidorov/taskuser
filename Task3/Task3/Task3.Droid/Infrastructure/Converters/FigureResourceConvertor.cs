using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using Task3.Domain.Models;

namespace Task3.Droid.Infrastructure.Converters
{
    public class FigureResourceConvertor : MvxValueConverter<Figure, int>
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
        protected override int Convert(Figure value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Figure.Apple: return Resource.Drawable.apple;
                case Figure.Strawberry: return Resource.Drawable.strawberry;
                case Figure.Banana: return Resource.Drawable.banane;
                default: return 0;
            }
        }
    }
}