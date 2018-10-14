using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.ValueConverters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using Task3.Core.Services;
using Task3.iOS.Infrastructure.Services;
using UIKit;

namespace Task3.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IMvxBindingContext, MvxBindingContext>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IDataBaseService, DataBaseService>();
            Mvx.LazyConstructAndRegisterSingleton<IPlatformService, PlatformService>();
            Mvx.LazyConstructAndRegisterSingleton<IConnectionService, ConnectionService>();
            Mvx.LazyConstructAndRegisterSingleton<IProgressDialogService, ProgressDialogService>();

            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxPluginManager CreatePluginManager()
        {
            return new MvxFilePluginManager(".iOS", ".dll");
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("CommandParameter", new MvxCommandParameterValueConverter());
        }
    }
}
