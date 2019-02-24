using System;
using System.Threading.Tasks;

namespace Task3.Core.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Диалоговое окно с 3-мя кнопками
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <param name="nextButtonContent"></param>
        /// <param name="lastButtonContent"></param>
        /// <returns></returns>
        Task<ButtonDialog> ShowMessage(string title, string message, string firstButtonContent,
            string nextButtonContent, string lastButtonContent);

        /// <summary>
        /// Диалоговое окно с двумя кнопками
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <param name="nextButtonContent"></param>
        /// <returns></returns>
        Task<bool?> ShowMessage(string title, string message, string firstButtonContent, string nextButtonContent);

        /// <summary>
        /// Диалоговое окно с одной кнопкой
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="firstButtonContent"></param>
        /// <returns></returns>
        Task<bool?> ShowMessage(string title, string message, string firstButtonContent);


        /// <summary>
        /// Диалоговое окно без заголовка и кнопок. Только для Андройда
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);

        /// <summary>
        /// Диалоговое окно с выбором времени
        /// </summary>
        /// <returns></returns>
        Task<DateTimeOffset> ShowTimeDialog(string title, HourType type = HourType.TwelveHour);

        /// <summary>
        /// Диалоговое окно с выбором даты
        /// </summary>
        /// <returns></returns>
        Task<DateTimeOffset> ShowDateDialog(string title);

        /// <summary>
        /// Диалоговое окно с полем ввода
        /// </summary>
        /// <returns></returns>
        Task<string> ShowInputDialog(string title, string hint = null, string messageInput = null, DialogInputType type = DialogInputType.None, bool isEmpty = false);
    }

    public enum CustomDialogType
    {
        None,
        ConfirmationMessage,
        Schedule,
        ListNumbers
    }

    public enum HourType
    {
        TwentyFourHour,
        TwelveHour
    }

    public enum ButtonDialog
    {
        Primary,
        Secondary,
        Close
    }
    public enum DialogInputType
    {
        Email,
        None
    }
}
