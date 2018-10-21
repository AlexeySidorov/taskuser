using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Platform;
using Task3.Core.Collections;
using Task3.Domain.Models;
using Task3.Services;

namespace Task3.Providers
{
    public class UserProvider : ItemsProvider<User>
    {
        private readonly IUserService _userService;

        public UserProvider()
        {
            _userService = Mvx.Resolve<IUserService>();
        }

        public async Task<int> FetchCount()
        {
            return await _userService.CountUsers();
        }

        public async Task<IList<User>> FetchRange(int startIndex, int count)
        {
            OnLoadingStart();

            var result = await _userService.GetAllUsers(startIndex, count);
            if (result == null)
            {
                OnLoadingStop();
                return new List<User>();
            }

            OnLoadingStop();

            return result;
        }

        public event EventHandler LoadingStart;
        public event EventHandler LoadingStop;
        public event EventHandler NotLoad;
        public event EventHandler<string> Error;

        protected virtual void OnLoadingStart()
        {
            var handler = LoadingStart;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLoadingStop()
        {
            var handler = LoadingStop;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
