using MvvmCross.Platform.IoC;

namespace Task3
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<Core.ViewModels.FirstViewModel>();
        }
    }
}
