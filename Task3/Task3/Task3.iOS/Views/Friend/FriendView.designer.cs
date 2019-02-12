// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Task3.iOS.Views.Friend
{
    [Register ("FriendView")]
    partial class FriendView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel About { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Coordinates { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Figure { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FriendsListTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserAge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView UserHeader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView UsersTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (About != null) {
                About.Dispose ();
                About = null;
            }

            if (Coordinates != null) {
                Coordinates.Dispose ();
                Coordinates = null;
            }

            if (Figure != null) {
                Figure.Dispose ();
                Figure = null;
            }

            if (FriendsListTitle != null) {
                FriendsListTitle.Dispose ();
                FriendsListTitle = null;
            }

            if (UserAddress != null) {
                UserAddress.Dispose ();
                UserAddress = null;
            }

            if (UserAge != null) {
                UserAge.Dispose ();
                UserAge = null;
            }

            if (UserDate != null) {
                UserDate.Dispose ();
                UserDate = null;
            }

            if (UserEmail != null) {
                UserEmail.Dispose ();
                UserEmail = null;
            }

            if (UserHeader != null) {
                UserHeader.Dispose ();
                UserHeader = null;
            }

            if (UserName != null) {
                UserName.Dispose ();
                UserName = null;
            }

            if (UserPhone != null) {
                UserPhone.Dispose ();
                UserPhone = null;
            }

            if (UsersTableView != null) {
                UsersTableView.Dispose ();
                UsersTableView = null;
            }
        }
    }
}