using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.Core;
using UIKit;


namespace Task3.iOS.Infrastructure.DataSources
{
    public class UserTableSource : MvxTableViewSource
    {
        public UserTableSource(UITableView tableView) : base(tableView)
        {
            UseAnimations = true;
            AddAnimation = UITableViewRowAnimation.Top;
            RemoveAnimation = UITableViewRowAnimation.Middle;
            tableView.RegisterNibForCellReuse(UINib.FromName("UserViewCell", NSBundle.MainBundle), UserViewCell.Key);
        }

        public UserTableSource(IntPtr handle) : base(handle)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = tableView.DequeueReusableCell(UserViewCell.Key, indexPath);
            if (cell is IMvxDataConsumer bindable)
                bindable.DataContext = item;

            cell.SelectionStyle = UITableViewCellSelectionStyle.None;

            return cell;
        }
    }
}