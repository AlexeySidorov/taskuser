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
        private UserTableSource _source;

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

            _source = new UserTableSource(UsersTableView);

            UsersTableView.Source = _source;
            UsersTableView.RowHeight = 86f;
            UsersTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            UsersTableView.ReloadData();

            Binding();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(114, 0, 202);
            NavigationController.NavigationBar.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });
        }

        private void Binding()
        {
            var set = this.CreateBindingSet<UsersView, UsersViewModel>();
            set.Bind(_source).To(vm => vm.Users).Apply();
            set.Bind(_source).For(s => s.SelectionChangedCommand).To(vm => vm.SelectUserСommand).Apply();
        }
    }
}
