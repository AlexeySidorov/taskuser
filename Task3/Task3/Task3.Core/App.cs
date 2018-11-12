using System.Linq;
using System.Reflection;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Task3.Core;
using Task3.Core.DataBaseService;
using Task3.Domain.Models;
using Task3.Services;

namespace Task3
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            ProjectSettings.DbName = "task3.db";

            //Регистрация репозиториев
            Mvx.RegisterType<IAsyncRepository<User>, AsyncRepository<User>>();
            Mvx.RegisterType<IAsyncRepository<Tag>, AsyncRepository<Tag>>();
            Mvx.RegisterType<IAsyncRepository<Friend>, AsyncRepository<Friend>>();

            //Регистрация сервисов
            typeof(UserService).GetTypeInfo().Assembly.CreatableTypes().Where(t => t.Name.EndsWith("Service")).AsInterfaces();
            
            RegisterAppStart(new CustomApp());
        }
    }
}
