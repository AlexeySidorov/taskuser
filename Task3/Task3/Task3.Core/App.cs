using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Task3.Core;
using Task3.Core.DataBaseService;
using Task3.Domain.Models;
using Task3.Services;
using Task3.ViewModels;

namespace Task3
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override async void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            ProjectSettings.DbName = "task3.db3";

            //����������� ������������
            Mvx.RegisterType<IAsyncRepository<User>, AsyncRepository<User>>();
            Mvx.RegisterType<IAsyncRepository<Tag>, AsyncRepository<Tag>>();
            Mvx.RegisterType<IAsyncRepository<Friend>, AsyncRepository<Friend>>();

            //����������� ��������
            typeof(UserService).GetTypeInfo().Assembly.CreatableTypes().Where(t => t.Name.EndsWith("Service")).AsInterfaces();

            //�������� ���� ������
            await Task.Run(() => new DataBase().CreateDataBase(new List<Assembly>() { typeof(User).GetTypeInfo().Assembly }));

            RegisterNavigationServiceAppStart<FirstViewModel>();
        }
    }
}
