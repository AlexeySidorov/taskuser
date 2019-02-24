using System;
using System.Globalization;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using GlobalToast;
using Task3.Core.Services;
using UIKit;

namespace Task3.iOS.Infrastructure.Services
{
    public class DialogService : IDialogService
    {
        private UITextField _field;

        public Task<ButtonDialog> ShowMessage(string title, string message, string firstButtonContent, string nextButtonContent,
            string lastButtonContent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Диалоговое окно с двумя кнопками
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <param name="nextButtonContent"></param>
        /// <returns></returns>
        public async Task<bool?> ShowMessage(string title, string message, string firstButtonContent,
            string nextButtonContent)
        {
            var tcs = new TaskCompletionSource<bool?>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            var alertDialog = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alertDialog.AddAction(UIAlertAction.Create(firstButtonContent, UIAlertActionStyle.Default, button => { tcs.TrySetResult(true); }));
            alertDialog.AddAction(UIAlertAction.Create(nextButtonContent, UIAlertActionStyle.Cancel, button => { tcs.TrySetResult(false); }));
            vc.PresentViewController(alertDialog, true, null);

            return await tcs.Task;
        }

        /// <summary>
        /// Диалоговое окно с одной кнопкой
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <returns></returns>
        public async Task<bool?> ShowMessage(string title, string message, string firstButtonContent)
        {
            var tcs = new TaskCompletionSource<bool?>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            var alertDialog = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alertDialog.AddAction(UIAlertAction.Create(firstButtonContent, UIAlertActionStyle.Default, button => { tcs.TrySetResult(true); }));
            vc.PresentViewController(alertDialog, true, null);

            return await tcs.Task;
        }

        /// <summary>
        /// Диалоговое окно без заголовка и кнопок
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public void ShowMessage(string message)
        {
            Toast.ShowToast(message).Show();
        }

        /// <summary>
        /// Диалоговое окно с выбором времени
        /// </summary>
        /// <returns></returns>
        public async Task<DateTimeOffset> ShowTimeDialog(string title, HourType type)
        {
            var tcs = new TaskCompletionSource<DateTimeOffset>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            var alertDialog = UIAlertController.Create(title, "\n\n\n\n\n\n\n\n\n", UIAlertControllerStyle.Alert);
            var pickerFrame = new CGRect(5, 45, 255, 150);
            var picker = new UIDatePicker(pickerFrame) { Mode = UIDatePickerMode.Time };
            alertDialog.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, button =>
            {
                tcs.TrySetResult(DateTimeOffset.Parse(NsDateToDateTime(picker.Date).ToString("hh:mm tt", CultureInfo.InvariantCulture)));

            }));
            alertDialog.Add(picker);
            vc.PresentViewController(alertDialog, true, null);

            return await tcs.Task;
        }

        /// <summary>
        /// Диалоговое окно с выбором даты
        /// </summary>
        /// <returns></returns>
        public async Task<DateTimeOffset> ShowDateDialog(string title)
        {
            var tcs = new TaskCompletionSource<DateTimeOffset>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            var alertDialog = UIAlertController.Create(title, "\n\n\n\n\n\n\n\n\n", UIAlertControllerStyle.Alert);
            var pickerFrame = new CGRect(5, 45, 255, 150);
            var picker = new UIDatePicker(pickerFrame) { Mode = UIDatePickerMode.Date };
            alertDialog.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, button =>
            {
                var date = NsDateToDateTime(picker.Date).Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                tcs.TrySetResult(DateTimeOffset.Parse(date));
            }));
            alertDialog.Add(picker);
            vc.PresentViewController(alertDialog, true, null);

            return await tcs.Task;
        }

        public async Task<string> ShowInputDialog(string title, string hint = null, string messageInput = null,
            DialogInputType type = DialogInputType.None, bool isEmpty = false)
        {
            return await ShowInputDialog(title, hint, messageInput, isEmpty);
        }

        /// <summary>
        /// Диалоговое окно с полем ввода
        /// </summary>
        /// <returns></returns>
        public async Task<string> ShowInputDialog(string title, string hint = null, string messageInput = null, bool isEmpty = false)
        {
            var tcs = new TaskCompletionSource<string>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            var alertDialog = UIAlertController.Create(title, null, UIAlertControllerStyle.Alert);
            alertDialog.AddTextField(((textField) =>
            {
                _field = textField;
                _field.Placeholder = hint;
                _field.Text = messageInput;
                _field.AutocorrectionType = UITextAutocorrectionType.No;
                _field.KeyboardType = UIKeyboardType.Default;
                _field.ReturnKeyType = UIReturnKeyType.Done;
                _field.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                _field.TextColor = UIColor.Black;
            }));

            alertDialog.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, button => { tcs.TrySetResult(_field.Text); }));
            alertDialog.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, button => { tcs.TrySetResult(null); }));
            vc.PresentViewController(alertDialog, true, null);

            return await tcs.Task;
        }

        private static DateTime NsDateToDateTime(NSDate date)
        {
            var reference = new DateTime(2001, 1, 1, 0, 0, 0);
            var currentDate = reference.AddSeconds(date.SecondsSinceReferenceDate);
            var localDate = currentDate.ToLocalTime();
            return localDate;
        }


    }
}