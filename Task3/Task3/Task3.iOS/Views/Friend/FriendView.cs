using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Task3.iOS.Infrastructure.DataSources;
using Task3.ViewModels;
using UIKit;

namespace Task3.iOS.Views.Friend
{
    [MvxFromStoryboard]
    public partial class FriendView : MvxViewController<FriendViewModel>
    {
        private UserTableSource _source;

        public FriendView()
        {

        }

        public FriendView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _source = new UserTableSource(UsersTableView);

            UsersTableView.TableHeaderView = UserHeader;
            
            UsersTableView.Source = _source;
            UsersTableView.RowHeight = 86f;
            UsersTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            UsersTableView.ReloadData();

          //  Binding();

            View.BackgroundColor = UIColor.White;
        }
        
        private void Binding()
        {
            var set = this.CreateBindingSet<FriendView, FriendViewModel>();
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