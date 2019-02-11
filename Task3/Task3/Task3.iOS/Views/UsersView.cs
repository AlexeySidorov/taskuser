using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Task3.iOS.Infrastructure.DataSources;
using Task3.ViewModels;
using UIKit;

namespace Task3.iOS.Views
{
    [MvxFromStoryboard]
    public partial class UsersView : BaseView<UsersViewModel>
    {
        private UserTableSource _source;

        public UsersView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            Title = "Users";
            NavigationItem.HidesBackButton = true;

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
            NavigationController.SetNavigationBarHidden(false, true);

            base.ViewWillAppear(animated);

            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(114, 0, 202);
            NavigationController.NavigationBar.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.Black });
        }

        private void Binding()
        {
            var set = this.CreateBindingSet<UsersView, UsersViewModel>();
            set.Bind(_source).To(vm => vm.Users).Apply();
            set.Bind(_source).For(s => s.SelectionChangedCommand).To(vm => vm.SelectUserСommand).Apply();
        }

        /// <summary>
        /// Скрыть/Показать статус бар
        /// </summary>
        /// <returns></returns>
        public override bool PrefersStatusBarHidden() => false;
    }
}
