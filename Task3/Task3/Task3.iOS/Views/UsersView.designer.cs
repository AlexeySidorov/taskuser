﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Task3.iOS.Views
{
    [Register ("UsersView")]
    partial class UsersView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView UsersTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (UsersTableView != null) {
                UsersTableView.Dispose ();
                UsersTableView = null;
            }
        }
    }
}