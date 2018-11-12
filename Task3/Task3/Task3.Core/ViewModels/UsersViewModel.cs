using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Task3.Core.Collections;
using Task3.Core.Services;
using Task3.Domain.Models;
using Task3.Providers;
using Task3.Services;

namespace Task3.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private readonly IUserService _userService;
        private AsyncVirtualizingCollection<User> _users;
        private MvxCommand<User> _selectedUserCommand;

        public UsersViewModel(IConnectionService connectionService, IDialogService dialogService, IUserService userService)
        {
            _connectionService = connectionService;
            _dialogService = dialogService;
            _userService = userService;
        }

        #region Binding

        public AsyncVirtualizingCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public ICommand SelectUserСommand
        {
            get
            {
                _selectedUserCommand = _selectedUserCommand ?? new MvxCommand<User>(MySelectUser);
                return _selectedUserCommand;
            }
        }

        #endregion

        public async void Init(string parameter)
        {
            var isUsers = await _userService.IsUsers();
            if (!await _connectionService.IsConnectedHost("www.google.com"))
            {
                if (!isUsers)
                {
                    await _dialogService.ShowMessage("Ошибка", "Отсутствует соединение с интернетом", "OK");
                    return;
                }
            }

            if (!isUsers)
            {
                var result = await RestApi.RestRequest.GetUsers();
                if (result != null)
                    await _userService.AddUsers(result);
            }

            Users = new AsyncVirtualizingCollection<User>(new UserProvider(), 6);
        }

        private void MySelectUser(User user)
        {
            if (user != null && user.IsActive)
                ShowViewModel<FriendViewModel>(user);
        }
    }
}
