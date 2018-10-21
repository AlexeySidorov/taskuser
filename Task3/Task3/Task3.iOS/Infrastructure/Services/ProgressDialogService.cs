using Task3.Core.Services;
using UIKit;

namespace Task3.iOS.Infrastructure.Services
{
    public class ProgressDialogService : IProgressDialogService
    {
        private LoadingOverlay _progress;
        private UIViewController _viewController;

        /// <summary>
        /// Открыть диалоговое окно
        /// </summary>
        /// <param name="message"></param>
        public void ShowDialog(string message)
        {
            if (_progress != null) return;

            _progress = new LoadingOverlay(UIScreen.MainScreen.Bounds, message);
            _viewController = UIApplication.SharedApplication.KeyWindow?.RootViewController;
            _viewController?.View.AddSubview(_progress);
        }

        /// <summary>
        /// Закрыть диалоговое окно
        /// </summary>
        public void CloseDialog()
        {
            if (_progress == null || _viewController == null) return;

            _progress.Hide();
            _progress.RemoveFromSuperview();
            _progress = null;
        }
    }
}
