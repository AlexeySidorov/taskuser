
namespace Task3.ViewModels
{
    public class FriendViewModel : BaseViewModel
    {
        public FriendViewModel()
        {
            
        }

        /// <summary>
        /// Получение данных из viewmodel
        /// </summary>
        /// <param name="parameter"></param>
        public void Init(string parameter)
        {
            //!string.IsNullOrEmpty(parameter) ? JsonConvert.DeserializeObject<string>(parameter) : string.Empty;
        }
    }
}
