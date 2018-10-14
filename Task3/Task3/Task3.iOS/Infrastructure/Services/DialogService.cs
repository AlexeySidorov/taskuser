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
        private UIView _mainView;
        private UIImageView _alertView;

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

        /// <summary>
        /// Shows the custom message dialoig.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text">Text.</param>
        /// <param name="firstButtonName"></param>
        /// <param name="nextButtonName"></param>
        public async Task<ButtonDialog> ShowCustomMessageDialog(string title, string text, string firstButtonName, string nextButtonName)
        {
            var tcs = new TaskCompletionSource<ButtonDialog>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;

            if (viewController != null)
            {
                _mainView = new UIView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height)) { BackgroundColor = UIColor.Black };
                _mainView.Layer.Opacity = 0.7f;

                var padding = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? 230f : 80f;
                _alertView = new UIImageView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width - padding, 270f))
                {
                    Center = new CGPoint(UIScreen.MainScreen.Bounds.Width / 2, UIScreen.MainScreen.Bounds.Height / 2),
                    Image = UIImage.FromBundle("background_dialog"),
                    UserInteractionEnabled = true
                };

                var label = new UILabel(new CGRect(18f, (_alertView.Frame.Width / 2) / 2, _alertView.Frame.Width - 36f, _alertView.Frame.Width / 2 - 40f))
                {
                    TextColor = UIColor.Black,
                    Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Medium),
                    Lines = 4,
                    TextAlignment = UITextAlignment.Center,
                    Text = text
                };

                var close = new UIImageView(UIImage.FromBundle("close_dialog"))
                {
                    Frame = new CGRect(_alertView.Frame.Width - 27.5f, 15f, 12.5f, 12.5f),
                    UserInteractionEnabled = true
                };

                var labelTitle = new UILabel(new CGRect(16f, 10f, _alertView.Frame.Width - close.Frame.Width - 27.5f, 21f))
                {
                    TextColor = UIColor.Black,
                    Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Medium),
                    Lines = 1,
                    TextAlignment = UITextAlignment.Center,
                    Text = title
                };

                var button = new UIButton(new CGRect(12f, _alertView.Frame.Height - 55f, _alertView.Frame.Width - 24f, 70f));
                button.SetImage(UIImage.FromBundle("button_normal"), UIControlState.Normal);
                button.SetImage(UIImage.FromBundle("button_disabled"), UIControlState.Disabled);

                var labelTitleButton = new UILabel(new CGRect(0f, 0f, button.Frame.Width, 42f))
                {
                    TextColor = UIColor.White,
                    TextAlignment = UITextAlignment.Center,
                    Text = firstButtonName,
                    Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Medium)
                };

                button.AddSubview(labelTitleButton);
                button.TouchUpInside += (sender, args) =>
                {
                    _mainView.RemoveFromSuperview();
                    _alertView.RemoveFromSuperview();
                    tcs.TrySetResult(ButtonDialog.Primary);
                };

                var buttonCancel = new UIButton(new CGRect(12f, _alertView.Frame.Height - 110f, _alertView.Frame.Width - 24f, 70f));
                buttonCancel.SetImage(UIImage.FromBundle("button_normal"), UIControlState.Normal);
                buttonCancel.SetImage(UIImage.FromBundle("button_disabled"), UIControlState.Disabled);

                var labelTitleButtonCancel = new UILabel(new CGRect(0f, 0f, buttonCancel.Frame.Width, 42f))
                {
                    TextColor = UIColor.White,
                    TextAlignment = UITextAlignment.Center,
                    Text = nextButtonName,
                    Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Regular)
                };

                buttonCancel.AddSubview(labelTitleButtonCancel);
                buttonCancel.TouchUpInside += (sender, args) =>
                {
                    _mainView.RemoveFromSuperview();
                    _alertView.RemoveFromSuperview();
                    tcs.TrySetResult(ButtonDialog.Secondary);
                };

                close.AddGestureRecognizer(new UITapGestureRecognizer(() =>
                {
                    _mainView.RemoveFromSuperview();
                    _alertView.RemoveFromSuperview();
                    tcs.TrySetResult(ButtonDialog.Close);
                }));

                _alertView.AddSubviews(label, close, labelTitle, button, buttonCancel);
                viewController.View.AddSubviews(_mainView, _alertView);
            }

            return await tcs.Task;
        }

        /// <summary>
        /// Shows the custom message dialoig.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text">Text.</param>
        /// <param name="firstButtonName"></param>
        public async Task<ButtonDialog> ShowCustomMessageDialog(string title, string text, string firstButtonName)
        {
            var tcs = new TaskCompletionSource<ButtonDialog>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;

            if (viewController != null)
            {
                _mainView = new UIView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height)) { BackgroundColor = UIColor.Black };
                _mainView.Layer.Opacity = 0.7f;

                var padding = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? 230f : 80f;
                _alertView = new UIImageView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width - padding, 220f))
                {
                    Center = new CGPoint(UIScreen.MainScreen.Bounds.Width / 2, UIScreen.MainScreen.Bounds.Height / 2),
                    Image = UIImage.FromBundle("background_dialog"),
                    UserInteractionEnabled = true
                };

                var label = new UILabel(new CGRect(18f, (_alertView.Frame.Width / 2) / 2, _alertView.Frame.Width - 36f, _alertView.Frame.Width / 2 - 40f))
                {
                    TextColor = UIColor.Black,
                    Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Medium),
                    Lines = 4,
                    TextAlignment = UITextAlignment.Center,
                    Text = text
                };

                var close = new UIImageView(UIImage.FromBundle("close_dialog"))
                {
                    Frame = new CGRect(_alertView.Frame.Width - 27.5f, 15f, 12.5f, 12.5f),
                    UserInteractionEnabled = true
                };

                var labelTitle = new UILabel(new CGRect(16f, 10f, _alertView.Frame.Width - close.Frame.Width - 27.5f, 21f))
                {
                    TextColor = UIColor.Black,
                    Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Medium),
                    Lines = 1,
                    TextAlignment = UITextAlignment.Center,
                    Text = title
                };

                var button = new UIButton(new CGRect(12f, _alertView.Frame.Height - 55f, _alertView.Frame.Width - 24f, 70f));
                button.SetImage(UIImage.FromBundle("button_normal"), UIControlState.Normal);
                button.SetImage(UIImage.FromBundle("button_disabled"), UIControlState.Disabled);

                var labelTitleButton = new UILabel(new CGRect(0f, 0f, button.Frame.Width, 42f))
                {
                    TextColor = UIColor.White,
                    TextAlignment = UITextAlignment.Center,
                    Text = firstButtonName,
                    Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Medium)
                };

                button.AddSubview(labelTitleButton);
                button.TouchUpInside += (sender, args) =>
                {
                    _mainView.RemoveFromSuperview();
                    _alertView.RemoveFromSuperview();
                    tcs.TrySetResult(ButtonDialog.Primary);
                };

                close.AddGestureRecognizer(new UITapGestureRecognizer(() =>
                {
                    _mainView.RemoveFromSuperview();
                    _alertView.RemoveFromSuperview();
                    tcs.TrySetResult(ButtonDialog.Close);
                }));

                _alertView.AddSubviews(label, close, labelTitle, button);
                viewController.View.AddSubviews(_mainView, _alertView);
            }

            return await tcs.Task;
        }
    }
}