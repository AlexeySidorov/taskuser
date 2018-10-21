// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Task3.iOS.Infrastructure.DataSources
{
    [Register ("UserViewCell")]
    partial class UserViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ActiveIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Arrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Email { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NickName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActiveIcon != null) {
                ActiveIcon.Dispose ();
                ActiveIcon = null;
            }

            if (Arrow != null) {
                Arrow.Dispose ();
                Arrow = null;
            }

            if (Email != null) {
                Email.Dispose ();
                Email = null;
            }

            if (NickName != null) {
                NickName.Dispose ();
                NickName = null;
            }
        }
    }
}