using BigTed;
using Task3.Core.Services;

namespace Task3.iOS.Infrastructure.Services
{
    public class ProgressDialogService : IProgressDialogService
    {
        /// <summary>
        /// Открыть диалоговое окно
        /// </summary>
        /// <param name="message"></param>
        public void ShowDialog(string message)
        {
            BTProgressHUD.Show(message, -1f, ProgressHUD.MaskType.Black);
        }

        /// <summary>
        /// Закрыть диалоговое окно
        /// </summary>
        public void CloseDialog()
        {
            BTProgressHUD.Dismiss();
        }
    }
}
