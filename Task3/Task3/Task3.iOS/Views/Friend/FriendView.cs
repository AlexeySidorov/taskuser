using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views.Gestures;
using MvvmCross.iOS.Views;
using Task3.iOS.Infrastructure.Converters;
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

            Status.Layer.CornerRadius = Status.Frame.Height / 2;

            Binding();

            View.BackgroundColor = UIColor.White;
        }

        private void Binding()
        {
            var set = this.CreateBindingSet<FriendView, FriendViewModel>();
            set.Bind(UserName).For(u => u.Text).To(vm => vm.UserName).Apply();
            set.Bind(UserAge).For(u => u.Text).To(vm => vm.UserAge).Apply();
            set.Bind(UserDate).For(u => u.Text).To(vm => vm.DateReg).Apply();
            set.Bind(UserEmail).For(u => u.Text).To(vm => vm.Email).Apply();
            set.Bind(UserPhone).For(u => u.Text).To(vm => vm.Phone).Apply();
            set.Bind(UserAddress).For(u => u.Text).To(vm => vm.Address).Apply();
            set.Bind(Coordinates).For(u => u.Text).To(vm => vm.Coordinates).Apply();
            set.Bind(About).For(u => u.Text).To(vm => vm.About).Apply();
            set.Bind(FriendsListTitle).For(u => u.Text).To(vm => vm.FriendsListTitle).Apply();
            set.Bind(UserEmail.Tap()).For(u => u.Command).To(vm => vm.SendEmailCommand).Apply();
            set.Bind(UserPhone.Tap()).For(u => u.Command).To(vm => vm.CallCommand).Apply();
            set.Bind(Coordinates.Tap()).For(u => u.Command).To(vm => vm.ShowMapCommand).Apply();
            set.Bind(Figure).For(v => v.Image).To(vm => vm.Figure).WithConversion<FigureResourceConvertor>().Apply();
            set.Bind(Status).For(v => v.BackgroundColor).To(vm => vm.StatusColor).WithConversion<StatusColorConvertor>().Apply();
            set.Bind(_source).To(vm => vm.Users).Apply();
            set.Bind(_source).For(s => s.SelectionChangedCommand).To(vm => vm.SelectUserСommand).Apply();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            About.SizeToFit();

            var headerView = UsersTableView.TableHeaderView;
            if (headerView != null)
            {
                var headerFrame = headerView.Frame;
                headerFrame.Height = About.Frame.Bottom + 46;
                headerView.Frame = headerFrame;
                UsersTableView.TableHeaderView = headerView;
            }
        }

        /// <summary>
        /// Скрыть/Показать статус бар
        /// </summary>
        /// <returns></returns>
        public override bool PrefersStatusBarHidden() => false;
    }
}