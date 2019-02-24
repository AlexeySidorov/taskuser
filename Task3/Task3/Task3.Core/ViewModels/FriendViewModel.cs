using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using Task3.Core.Services;
using Task3.Domain.Models;
using Task3.Services;

namespace Task3.ViewModels
{
    public class FriendViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IPlatformService _platformService;
        private string _nameUser;
        private string _ageUser;
        private string _dateReg;
        private string _email;
        private string _phone;
        private string _address;
        private string _coordinates;
        private string _about;
        private MvxObservableCollection<User> _users;
        private MvxCommand<User> _selectedUserCommand;
        private string _friendsListTitle;
        private User _user;
        private MvxCommand _callCommand;
        private MvxCommand _sendEmailCommand;
        private MvxCommand _showMapCommand;
        private Figure _figure;

        // ReSharper disable once EmptyConstructor
        public FriendViewModel(IUserService userService, IPlatformService platformService)
        {
            _userService = userService;
            _platformService = platformService;
        }

        #region Binding

        public string UserName
        {
            get => _nameUser;
            set
            {
                if (value == _nameUser) return;
                _nameUser = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string UserAge
        {
            get => _ageUser;
            set
            {
                if (value == _ageUser) return;
                _ageUser = value;
                RaisePropertyChanged(() => UserAge);
            }
        }

        public string DateReg
        {
            get => _dateReg;
            set
            {
                if (value == _dateReg) return;
                _dateReg = value;
                RaisePropertyChanged(() => DateReg);
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == _email) return;
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (value == _phone) return;
                _phone = value;
                RaisePropertyChanged(() => Phone);
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (value == _address) return;
                _address = value;
                RaisePropertyChanged(() => Address);
            }
        }

        public string Coordinates
        {
            get => _coordinates;
            set
            {
                if (value == _coordinates) return;
                _coordinates = value;
                RaisePropertyChanged(() => Coordinates);
            }
        }

        public string About
        {
            get => _about;
            set
            {
                if (value == _about) return;
                _about = value;
                RaisePropertyChanged(() => About);
            }
        }

        public string FriendsListTitle
        {
            get => _friendsListTitle;
            set
            {
                if (value == _friendsListTitle) return;
                _friendsListTitle = value;
                RaisePropertyChanged(() => FriendsListTitle);
            }
        }

        public MvxObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public ICommand SelectUserÑommand
        {
            get
            {
                _selectedUserCommand = _selectedUserCommand ?? new MvxCommand<User>(MySelectUser);
                return _selectedUserCommand;
            }
        }

        public ICommand CallCommand
        {
            get
            {
                _callCommand = _callCommand ?? new MvxCommand(Call);
                return _callCommand;
            }
        }
        public ICommand SendEmailCommand
        {
            get
            {
                _sendEmailCommand = _sendEmailCommand ?? new MvxCommand(SendEmail);
                return _sendEmailCommand;
            }
        }

        public ICommand ShowMapCommand
        {
            get
            {
                _showMapCommand = _showMapCommand ?? new MvxCommand(OpenMap);
                return _showMapCommand;
            }
        }

        public Figure Figure
        {
            get => _figure;
            set
            {
                if (value == _figure) return;
                _figure = value;
                RaisePropertyChanged(() => Figure);
            }
        }

        public ColorType StatusColor { get; set; }

        #endregion

        /// <summary>
        /// Ïîëó÷åíèå äàííûõ èç viewmodel
        /// </summary>
        /// <param name="parameter"></param>
        public void Init(string parameter)
        {
            if (string.IsNullOrEmpty(parameter) || string.IsNullOrWhiteSpace(parameter)) return;

            _user = JsonConvert.DeserializeObject<User>(parameter);

            if (_user != null)
            {
                UserName = string.IsNullOrEmpty(_user.Name) || string.IsNullOrWhiteSpace(_user.Name) ? "Not specified" : _user.Name;
                UserAge = _user.Age.ToString();
                DateReg = _user.Registered.ToString("HH:mm dd.MM.yy");
                Email = string.IsNullOrEmpty(_user.Email) || string.IsNullOrWhiteSpace(_user.Email) ? "Not specified" : _user.Email;
                Phone = string.IsNullOrEmpty(_user.Phone) || string.IsNullOrWhiteSpace(_user.Phone) ? "Not specified" : _user.Phone;
                Address = string.IsNullOrEmpty(_user.Address) || string.IsNullOrWhiteSpace(_user.Address) ? "Not specified" : _user.Address;
                Coordinates = $"{_user.Latitude}, {_user.Longitude}";
                About = string.IsNullOrEmpty(_user.About) || string.IsNullOrWhiteSpace(_user.About) ? "Not specified" : _user.About;
                FriendsListTitle = string.IsNullOrEmpty(_user.Name) || string.IsNullOrWhiteSpace(_user.Name)
                    ? "Friends"
                    : $"Friends by {_user.Name}";
                Figure = _user.FavoriteFruit;
                StatusColor = _user.EyeColor;
            }
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();

            if (_user?.Friends == null || _user?.Friends.Count == 0) return;

            var friends = await _userService.GetUserByIds(_user.Friends.Select(f => f.FriendId).ToList());
            Users = new MvxObservableCollection<User>(friends);
        }

        private void MySelectUser(User user)
        {
            if (user != null && user.IsActive)
                ShowViewModel<FriendViewModel>(user);
        }

        private void Call()
        {
            if (string.IsNullOrEmpty(_user.Phone) || string.IsNullOrWhiteSpace(_user.Phone)) return;

            _platformService.CallPhone(_user.Phone);
        }

        private void SendEmail()
        {
            if (string.IsNullOrEmpty(_user.Email) || string.IsNullOrWhiteSpace(_user.Email)) return;

            _platformService.SendEmail(_user.Email);
        }

        private void OpenMap()
        {
            _platformService.ShowMapsApplication(_user.Latitude, _user.Longitude);
        }
    }
}
