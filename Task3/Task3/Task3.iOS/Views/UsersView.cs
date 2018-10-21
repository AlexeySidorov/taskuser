using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Task3.iOS.Infrastructure.DataSources;
using Task3.ViewModels;
using UIKit;

namespace Task3.iOS.Views
{
    [MvxFromStoryboard]
    public partial class UsersView : MvxViewController<UsersViewModel>
    {
        public UsersView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            Title = "Users";

            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
            UIApplication.SharedApplication.StatusBarHidden = false;
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;

            base.ViewDidLoad();

            var source = new UserTableSource(UsersTableView);
            var set = this.CreateBindingSet<UsersView, UsersViewModel>();
            set.Bind(source).To(vm => vm.Users);
            set.Apply();

            UsersTableView.Source = source;
            UsersTableView.RowHeight = 86f;
            UsersTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            UsersTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(114, 0, 202);
            NavigationController.NavigationBar.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });
        }
    }
}
