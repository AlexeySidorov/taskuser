using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Logging;
using MvvmCross.Platform.Platform;
using Task3.Core.Services;
using Task3.Droid.Infrastructure.Services;

namespace Task3.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        //protected override MvxLogProviderType GetDefaultLogProviderType()
        //    => MvxLogProviderType.None;

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterType<IMvxBindingContext, MvxBindingContext>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IDataBaseService, DataBaseService>();
            Mvx.LazyConstructAndRegisterSingleton<IPlatformService, PlatformService>();
            Mvx.LazyConstructAndRegisterSingleton<IConnectionService, ConnectionService>();
            Mvx.LazyConstructAndRegisterSingleton<IProgressDialogService, ProgressDialogService>();

            base.InitializeFirstChance();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Toolbar).Assembly,
            typeof(NavigationView).Assembly,
            typeof(DrawerLayout).Assembly,
            typeof(ViewPager).Assembly,
            typeof(AppCompatImageButton).Assembly,
            typeof(AppCompatButton).Assembly,
            typeof(NestedScrollView).Assembly,
            typeof(CardView).Assembly,
            typeof(MvxListView).Assembly,
            typeof(MvxGridView).Assembly,
            typeof(MvxImageView).Assembly,
            typeof(MvxAppCompatImageView).Assembly,
            typeof(MvxRecyclerView).Assembly,
        };

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }
    }
}
