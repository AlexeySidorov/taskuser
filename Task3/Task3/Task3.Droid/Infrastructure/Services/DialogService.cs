using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Text;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using Task3.Core.Services;
using Task3.Droid.Infrastructure.Converters;
using Task3.Droid.Infrastructure.Managers;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace Task3.Droid.Infrastructure.Services
{
    public class DialogService : IDialogService
    {
        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <param name="nextButtonContent"></param>
        /// <returns></returns>
        public async Task<bool?> ShowMessage(string title, string message, string firstButtonContent, string nextButtonContent)
        {
            var tcs = new TaskCompletionSource<bool?>();
            var builder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity, Resource.Style.AppCompatAlertDialogStyle);
            builder.SetTitle(title)
                .SetMessage(message)
                .SetCancelable(false)
                .SetPositiveButton(firstButtonContent, (s, args) => { tcs.TrySetResult(true); })
                .SetNegativeButton(nextButtonContent, (s, args) => { tcs.TrySetResult(false); });

            var alert = builder.Create();
            alert.Show();

            var btnPositive = alert.GetButton((int)DialogButtonType.Positive);
            var btnNegative = alert.GetButton((int)DialogButtonType.Negative);
            var layoutParams = (LinearLayout.LayoutParams)btnPositive.LayoutParameters;

            layoutParams.Gravity = GravityFlags.Center;

            btnPositive.LayoutParameters = layoutParams;
            btnNegative.LayoutParameters = layoutParams;

            return await tcs.Task;
        }

        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <param name="nextButtonContent"></param>
        /// <param name="lastButtonContent"></param>
        /// <returns></returns>
        public async Task<ButtonDialog> ShowMessage(string title, string message, string firstButtonContent, string nextButtonContent, string lastButtonContent)
        {
            var tcs = new TaskCompletionSource<ButtonDialog>();
            var builder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity, Resource.Style.AppCompatAlertDialogStyle);
            builder.SetTitle(title)
                .SetMessage(message)
                .SetCancelable(false)
                .SetPositiveButton(firstButtonContent, (s, args) => { tcs.TrySetResult(ButtonDialog.Primary); })
                .SetNeutralButton(lastButtonContent, (s, args) => { tcs.TrySetResult(ButtonDialog.Close); })
                .SetNegativeButton(nextButtonContent, (s, args) => { tcs.TrySetResult(ButtonDialog.Secondary); });

            var alert = builder.Create();

            alert.Show();

            var btnPositive = alert.GetButton((int)DialogButtonType.Positive);
            var btnNegative = alert.GetButton((int)DialogButtonType.Negative);
            var btnNeutral = alert.GetButton((int)DialogButtonType.Neutral);
            var layoutParams = (LinearLayout.LayoutParams)btnPositive.LayoutParameters;

            layoutParams.Gravity = GravityFlags.Center;

            btnPositive.LayoutParameters = layoutParams;
            btnNegative.LayoutParameters = layoutParams;
            btnNeutral.LayoutParameters = layoutParams;

            return await tcs.Task;
        }

        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <returns></returns>
        public async Task<bool?> ShowMessage(string title, string message, string firstButtonContent)
        {
            var tcs = new TaskCompletionSource<bool?>();
            var builder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity, Resource.Style.AppCompatAlertDialogStyle);
            builder.SetTitle(title)
                .SetMessage(message)
                .SetCancelable(false)
                .SetPositiveButton(firstButtonContent, (s, args) => { tcs.TrySetResult(true); });

            builder.Create().Show();

            return await tcs.Task;
        }

        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public void ShowMessage(string message)
        {
            Toast.MakeText(CrossCurrentActivity.Current.Activity, message, ToastLength.Short);
        }

        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <returns></returns>
        public async Task<DateTimeOffset> ShowTimeDialog(string title, HourType type = HourType.TwelveHour)
        {
            var tcs = new TaskCompletionSource<DateTimeOffset>();
            var timeDialog = new TimePickerDialog(CrossCurrentActivity.Current.Activity, Resource.Style.AppCompatDialogStyle,
                (sender, args) =>
                {
                    if (args == null)
                    {
                        tcs.TrySetResult(DateTime.Now);
                        return;
                    }

                    var time = DateTime.Today.Add(new TimeSpan(args.HourOfDay, args.Minute, 0));
                    tcs.TrySetResult(time);
                }, DateTime.Now.Hour, DateTime.Now.Minute, type == HourType.TwentyFourHour);
            timeDialog.SetTitle(title);
            timeDialog.SetCancelable(true);
            timeDialog.Show();
            return await tcs.Task;
        }

        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <returns></returns>
        public async Task<DateTimeOffset> ShowDateDialog(string title)
        {
            var tcs = new TaskCompletionSource<DateTimeOffset>();
            var dateDialog = new DatePickerDialog(CrossCurrentActivity.Current.Activity, Resource.Style.AppCompatDialogStyle,
                (sender, args) => { tcs.TrySetResult(args.Date); }, DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day);

            dateDialog.SetTitle(title);
            dateDialog.SetCancelable(true);
            dateDialog.Show();
            return await tcs.Task;
        }


        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <returns></returns>
        public async Task<string> ShowInputDialog(string title, string hint = null, string messageInput = null,
            // ReSharper disable once MethodOverloadWithOptionalParameter
            DialogInputType type = DialogInputType.None, bool isEmpty = false)
        {
            var tcs = new TaskCompletionSource<string>();

            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                var builder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
                var input = new EditText(CrossCurrentActivity.Current.Activity);
                var lp = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent);
                lp.SetMargins((int)ConvertScreenValue.ConvertDpToPixel(20, CrossCurrentActivity.Current.Activity), 0,
                    (int)ConvertScreenValue.ConvertDpToPixel(20, CrossCurrentActivity.Current.Activity), 0);
                input.LayoutParameters = lp;
                input.SetMaxLines(1);
                input.SetSingleLine(true);
                input.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(25) });
                input.Text = string.IsNullOrEmpty(messageInput) || isEmpty ? string.Empty : messageInput;
                input.Hint = string.IsNullOrEmpty(messageInput) && !string.IsNullOrEmpty(hint) ? hint : string.Empty;
                input.InputType = GetInputType(type);

                var view = new LinearLayout(CrossCurrentActivity.Current.Activity);
                var lpView = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent);
                view.LayoutParameters = lpView;
                view.AddView(input);
                view.Touch += (sender, args) => KeyboardManager.HideKeyboard(CrossCurrentActivity.Current.Activity, view);
                view.Click += (sender, args) => KeyboardManager.HideKeyboard(CrossCurrentActivity.Current.Activity, view);

                var dlg = new Dialog(CrossCurrentActivity.Current.Activity);
                var dlg1 = dlg;
                builder.SetTitle(title)
                    .SetView(view)
                    .SetPositiveButton("OK", (s, args) =>
                    {
                        KeyboardManager.HideKeyboard(CrossCurrentActivity.Current.Activity, view);
                        tcs.TrySetResult(input.Text);
                        dlg1.Dismiss();
                    })
                    .SetNegativeButton("Cancel", (s, args) =>
                    {
                        KeyboardManager.HideKeyboard(CrossCurrentActivity.Current.Activity, view);
                        tcs.TrySetResult(null);
                        dlg1.Dismiss();
                    });
                dlg = builder.Create();
                dlg.Show();
            });

            return await tcs.Task;
        }

        private InputTypes GetInputType(DialogInputType type)
        {
            switch (type)
            {
                case DialogInputType.Email:
                    return InputTypes.TextVariationEmailAddress;
                default:
                    return InputTypes.TextVariationNormal;
            }
        }
    }
}