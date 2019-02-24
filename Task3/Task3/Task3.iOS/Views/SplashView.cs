using System;
using MvvmCross.iOS.Views;
using Task3.ViewModels;
using UIKit;

namespace Task3.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "SplashView")]
    public sealed partial class SplashView : BaseView<SplashViewModel>
    {
        public SplashView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            NavigationController.SetNavigationBarHidden(true, false);

            base.ViewDidLoad();
        }

        public override void ViewDidDisappear(bool animated)
        {
            if (NavigationController != null)
            {
                var controllers = NavigationController.ViewControllers;
                var newControllers = new UIViewController[controllers.Length - 1];
                var index = 0;

                foreach (var item in controllers)
                {
                    if (item == this) continue;

                    newControllers[index] = item;
                    index++;
                }

                NavigationController.ViewControllers = newControllers;
            }

            base.ViewDidDisappear(animated);
        }

        /// <summary>
        /// Скрыть/Показать статус бар
        /// </summary>
        /// <returns></returns>
        public override bool PrefersStatusBarHidden() => false;
    }
}