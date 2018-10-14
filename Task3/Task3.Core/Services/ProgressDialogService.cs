namespace Task3.Core.Services
{
    public interface IProgressDialogService
    {
        /// <summary>
        /// Показать диалог с прогресс баром 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        void ShowDialog(string message);

        /// <summary>
        /// Закрыть диалог с прогресс баром 
        /// </summary>
        /// <returns></returns>
        void CloseDialog();
    }
}
