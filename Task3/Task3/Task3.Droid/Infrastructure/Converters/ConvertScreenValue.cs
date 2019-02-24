using Android.Content;
using Android.Util;

namespace Task3.Droid.Infrastructure.Converters
{
    public static class ConvertScreenValue
    {
        /// <summary>
        /// Конвертация DP to PX
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static float ConvertDpToPixel(int dp, Context context)
        {
            var resources = context.Resources;
            var metrics = resources.DisplayMetrics;
#pragma warning disable 618
            var px = dp * ((float)metrics.DensityDpi / (float) DisplayMetrics.DensityDefault);
#pragma warning restore 618

            return px;
        }

        /// <summary>
        ///  Конвертация PX to DP
        /// </summary>
        /// <param name="px"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static float ConvertPixelsToDp(float px, Context context)
        {
            var resources = context.Resources;
            var metrics = resources.DisplayMetrics;
#pragma warning disable 618
            var dp = px / ((float)metrics.DensityDpi / (float)DisplayMetrics.DensityDefault);
#pragma warning restore 618

            return dp;
        }
    }
}