using System;
using UIKit;

namespace Task3.iOS.Infrastructure.Extensions
{
    public static class UiColorExtension
    {
        /// <summary>
        /// Hex integer value color 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static UIColor FromHex(this UIColor color, int hexValue)
        {
            return UIColor.FromRGB(
                ((((hexValue & 0xFF0000) >> 16)) / 255.0f),
                ((((hexValue & 0xFF00) >> 8)) / 255.0f),
                (((hexValue & 0xFF)) / 255.0f)
            );
        }

        /// <summary>
        /// Hex string value 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="hexValue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static UIColor FromHex(this UIColor color, string hexValue, float alpha = 1.0f)
        {
            if (string.IsNullOrEmpty(hexValue)) return UIColor.Clear;

            var colorString = hexValue.Replace("#", string.Empty);
            if (alpha > 1.0f)
                alpha = 1.0f;
            else if (alpha < 0.0f)
                alpha = 0.0f;

            float red, green, blue;

            switch (colorString.Length)
            {
                case 3: // #RGB
                    {
                        red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
                        green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
                        blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
                        return UIColor.FromRGBA(red, green, blue, alpha);
                    }
                case 6: // #RRGGBB
                    {
                        red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                        green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                        blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                        return UIColor.FromRGBA(red, green, blue, alpha);
                    }

                default:
                    throw new ArgumentOutOfRangeException(
                        $"Invalid color value {hexValue} is invalid. It should be a hex value of the form #RBG, #RRGGBB");
            }
        }

        /// <summary>
        /// По умолчанию вернет черный цвет
        /// </summary>
        public static UIColor ToUiColor(this string source)
        {
            return source.ToUiColor(UIColor.Black);
        }

        /// <summary>
        /// Позволяет задать цвет по-умолчанию строкой *.*
        /// </summary>
        public static UIColor ToUiColor(this string source, string defaultColor)
        {
            return !string.IsNullOrEmpty(source) ? (UIColor.Clear).FromHex(source) : defaultColor.ToUiColor(UIColor.Clear);
        }

        public static UIColor ToUiColor(this string source, float alpha)
        {
            return (UIColor.Clear).FromHex(source, alpha);
        }

        /// <summary>
        /// Превращает из строки UIColor
        /// </summary>
        public static UIColor ToUiColor(this string source, UIColor defaultColor)
        {
            if (string.IsNullOrEmpty(source))
                return defaultColor;

            if (source.Contains("."))
                return UIColor.FromPatternImage(UIImage.FromFile(source));

            if (!string.IsNullOrEmpty(source))
                return !source.Contains(".") ? (UIColor.Clear).FromHex(source) : UIColor.FromPatternImage(UIImage.FromFile(source));

            return defaultColor;
        }
    }
}
