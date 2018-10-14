using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;

namespace Task3.Droid.Infrastructure.Managers
{
    public static class KeyboardManager
    {

        /// <summary>
        /// Закрыть клавиатуру
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(AppCompatActivity activity, View view)
        {
            if (activity != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        /// <summary>
        /// Закрыть клавиатуру
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(FragmentActivity activity, View view)
        {
            if (activity != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        /// <summary>
        /// Закрыть клавиатуру
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(Activity activity, View view)
        {
            if (activity != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        /// <summary>
        /// Закрыть клавиатуру
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        public static void HideKeyboard(Context context, View view)
        {
            if (context != null && view != null)
            {
                var inputMethodManager = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }
    }
}