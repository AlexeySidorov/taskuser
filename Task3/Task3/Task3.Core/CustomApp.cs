using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Task3.Core.DataBaseService;
using Task3.Core.Services;
using Task3.Domain.Models;
using Task3.ViewModels;

namespace Task3
{
    public class CustomApp : MvxNavigatingObject, IMvxAppStart
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <param name="hint"></param>
        public async void Start(object hint = null)
        {
            var navigationService = Mvx.Resolve<IMvxNavigationService>();
            //Инициализирует RootViewController
            if (Mvx.Resolve<IPlatformService>().Platform == Platform.Ios)
                await navigationService.Navigate<SplashViewModel>();
    
          //Создание Базы данных
          await Task.Run(() => new DataBase().CreateDataBase(new List<Assembly>() { typeof(User).GetTypeInfo().Assembly }));

            
            await navigationService.Navigate<UsersViewModel>();
        }
    }
}
