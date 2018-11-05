using System;
using MvvmCross.iOS.Views;
using Task3.ViewModels;
using UIKit;

namespace Task3.iOS.Views.Friend
{
    public partial class FriendView : MvxViewController<FriendViewModel>
    {
        public FriendView()
        {

        }

        public FriendView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            var header = new HeaderView();
            View.AddSubview(header);

            header.TopAnchor.ConstraintEqualTo(View.TopAnchor, 50).Active = true;
            header.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
            header.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            header.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
        }
    }
}