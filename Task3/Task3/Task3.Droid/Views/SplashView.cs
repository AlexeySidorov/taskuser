using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Transitions;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Plugin.Permissions;
using Task3.Droid.Infrastructure.Managers;
using Task3.Droid.Infrastructure.Navigates;
using Task3.ViewModels;

namespace Task3.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.StateAlwaysHidden)]
    public class SplashView : MvxAppCompatActivity<SplashViewModel>, INavigationActivity
    {
        private int _layout = Resource.Layout.base_view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(_layout);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                SetupWindowAnimations();

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
        }

        /// <summary>
        /// Toolbar base activity
        /// </summary>
        public Toolbar Toolbar { get; set; }

        public DrawerLayout DrawerLayout { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        /// <summary>
        /// WindowAnimations
        /// </summary>
        private void SetupWindowAnimations()
        {
            if (Build.VERSION.SdkInt == BuildVersionCodes.Lollipop)
            {
                var fade = new Fade();
                fade.SetDuration(1000);
                Window.EnterTransition = fade;
                var slide = new Slide();
                slide.SetDuration(1000);
                Window.ExitTransition = slide;
            }
        }

        /// <summary>
        /// Back pressed
        /// </summary>
        public override void OnBackPressed()
        {
            KeyboardManager.HideKeyboard(this, Toolbar);

            var fm = SupportFragmentManager;
            // ReSharper disable once SuspiciousTypeConversion.Global
            var backPressedListener = fm.Fragments.OfType<IBackPressedListener>().FirstOrDefault();
            
            if (backPressedListener != null && !backPressedListener.IsBaseBackPressed)
                backPressedListener.OnBackPressed();
            else if (fm.BackStackEntryCount == 1)
                Finish();
            else
                base.OnBackPressed();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // ReSharper disable once RedundantJumpStatement
            if (requestCode == -1) return;

        }

        /// <summary>
        /// Request permissions
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
