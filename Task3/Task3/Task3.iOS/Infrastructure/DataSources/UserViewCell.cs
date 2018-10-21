using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using Task3.Domain.Models;
using UIKit;

namespace Task3.iOS.Infrastructure.DataSources
{
    public partial class UserViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("UserViewCell");
        public static readonly UINib Nib;

        static UserViewCell()
        {
            Nib = UINib.FromName("UserViewCell", NSBundle.MainBundle);
        }

        protected UserViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
           {
               var set = this.CreateBindingSet<UserViewCell, User>();
               set.Bind(NickName).For(n => n.Text).To(item => item.Name);
               set.Bind(Email).For(e => e.Text).To(item => item.Email).WithConversion("NullToTextConvert");
               set.Bind(ActiveIcon).For(e => e.Image).To(item => item.IsActive).WithConversion("ActiveUserToImageConvert");
               set.Apply();

               Arrow.Image = UIImage.FromBundle("arrow_right");
           });         
        }
    }
}
